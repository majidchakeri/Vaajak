import React, { useState } from "react";
import { View, TextInput, Text, StyleSheet, TouchableOpacity } from "react-native";
import * as yup from 'yup';
import { Formik } from 'formik';
import axios from 'axios';
import DropShadow from "react-native-drop-shadow";
import AsyncStorage from '@react-native-async-storage/async-storage';

const validationSchema = yup.object().shape({
    email: yup.string().email().required(),
    password: yup.string().required().matches(
         /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/,
         "Must Contain 8 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character"
    ),
});

const Login = ( ) => {
    let [token, setToken] = useState('');
 
    return(
        <View style={styles.container}>
            <View style={styles.titleBox}>
                <Text style={styles.title}>SignIn</Text>
                <Text style={styles.subTitle}>Please enter your email and password for login.</Text>
            </View>
            <Formik initialValues={{email:'', password:''}}
                validationSchema={validationSchema}
                onSubmit={onSubmit}
            >

                {

                ({ values, errors, handleSubmit, handleBlur, handleChange }) => (
                    <DropShadow style={styles.shadowProp}>
                    <View style={styles.footer}>
                        <View style={styles.inputsbox}>
                            <View style={styles.action}>
                                {/* <Icon name="mail" size={40} color="#000" style={{ paddingTop: 12 }} /> */}
                                <TextInput style={styles.textInput} placeholder='Email' placeholderTextColor='#000' onBlur={handleBlur('email')} onChangeText={handleChange('email')} value={values.email} />
                            </View>
                            <Text style={styles.errorText}>{errors.email}</Text>

                            {/* placeholder="Email"  */}
                            <View style={styles.action}>
                                {/* <Icon name="lock1" size={40} color="#000" style={{ paddingTop: 12 }} /> */}
                                <TextInput style={styles.textInput} placeholder='Password' placeholderTextColor='#000' onBlur={handleBlur('password')} onChangeText={handleChange('password')} value={values.password} />
                            </View>
                            <Text style={styles.errorText}>{errors.password}</Text>
                        </View>

                        <View style={styles.submitbox}>
                            <TouchableOpacity style={styles.button} onPress={handleSubmit}>
                                <Text  style={styles.button} color='#000' onPress={handleSubmit}>SIGN IN</Text>
                            </TouchableOpacity>
                            <Text style={styles.link}>Forgot password?!</Text>
                        </View >
                    </View>
                    </DropShadow>

                )
                }
            </Formik>


            <TouchableOpacity onPress={() => props.navigation.navigate('signup')}>
                 <Text style={styles.link}>Don't have an account?! Sign up now</Text>
            </TouchableOpacity> 
        </View>
    )
}
const onSubmit = () => {
    console.log('submited');
    let url = '141.11.246.94:3000/api/v1/user/login'
    axios.post(url)
    .then(async(res)=>{
        await setToken(response.data.access_token);
        console.log(res);
    })
    .catch(err => console.log('errrrrrooooorrr',err))
}
const styles = StyleSheet.create({
    shadowProp: {
        shadowColor: '#171717',
        shadowOffset: {width: -2, height: 4},
        shadowOpacity: 0.3,
        shadowRadius: 2,
        width: '80%',
        alignItems: 'center',
      },
    container: {
        flex: 1,
       justifyContent: 'space-evenly',
       alignItems: 'center',
    //    backgroundColor: '#729fcf',
    },
   logoBox: {
       alignItems: 'center',
       width: '50%',
    },
   footer: {
        width: '80%',
        alignItems: 'center',
        // justifyContent: 'space-around',
        backgroundColor: '#fff',
        // borderWidth: 1,
        borderRadius: 20,
        borderStyle: 'dotted',
        borderColor: '#903779',

        },
    titleBox:{
        textAlign: 'left',
        width: '70%',
    },
    title:{
        fontSize: 25,
        fontWeight: "bold",
        color: '#903779',
    },
    subTitle:{
        fontSize: 18,
        color: '#903779',
    },
    inputsbox: {
        // justifyContent: 'space-around',
        // justifyContent: 'center',
        alignItems: 'center',
        paddingTop: 50,
        paddingBottom: 50,
    },
    action: {
        flexDirection: 'row',
        justifyContent: 'center',
        borderBottomWidth: 2,
        borderColor: '#000',
    },
    textInput: {
        justifyContent: 'center',
        marginTop: 10,
        fontSize: 20,
        width: '80%',
        color: '#000',
    },
    submitbox: {
        flexDirection: 'column',
        flexWrap: "wrap",
        alignContent: 'center',
        alignItems: 'center',
        width: '100%',
        // marginTop: 170,
     },
    button: {
        alignItems: 'center',
        textAlignVertical: 'center',
        textAlign: 'center',
        alignContent: 'space-around',
        borderRadius: 50,
        backgroundColor: '#00843d',
        color: '#fff',
        width: '70%',
        height: 50,
        fontSize: 22,
        fontWeight: 'bold',
    },
   link: {
       color: '#000',
       paddingBottom: 20,
       paddingTop: 10,
    },
   errorText: {
       color: 'red',
    },
});
export default Login;
