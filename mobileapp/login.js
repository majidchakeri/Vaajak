import React, { useState, } from 'react';
import { View, Text, TextInput, StyleSheet, TouchableOpacity } from 'react-native';
 import { Button } from 'react-native-paper';
 import Icon from 'react-native-vector-icons/AntDesign';
 import * as yup from 'yup';
 import { Formik } from 'formik';
import axios from 'axios';
import AsyncStorage from '@react-native-async-storage/async-storage';

 
 const validationSchema = yup.object().shape({

    email: yup.string().email().required(),
    password: yup.string().required().matches(
         /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/,
         "Must Contain 8 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character"

    ),
 })
const SignIn = (props) => {
    let [token, setToken] = useState('');
 
     return (
         <View style={styles.container}>
                 <Icon name="windowso" size={150} color={"#fff"} />
            {/* </View> */}
 
            <Formik initialValues={{ email: '', password: '' }}
                validationSchema={validationSchema}
                // onSubmit={(values) => { console.log(values) }}
                onSubmit={(values, { resetForm }) => {
                    axios({
                        method: 'POST',
                        url: 'Htttp://',
                        data: {
                            "email": values.email,
                            "password": values.password,
                        }

                    }).then( async (response) => {
                        setToken(response.data.access_token);
                        console.log(token);
                        // try {
                        //   await AsyncStorage.setItem('@jwt_token', response.data.access_token)

                        // } catch (error) {
                        //     console.log(error);
                        // }
                    }

                    )
                    .catch ((error) => {
                        if(error.response.data.non_field_errors){
                            setErrorText(error.response.data.non_field_errors[0]);
                            console.log(error.response.data.non_field_errors);
                            resetForm({values : ''});
                        } else {
                            setErrorText(error.response.data.username[0]);
                            console.log(error.response.data.username);
                            resetForm({values : ''});
                        }
                    })
                }}
 
            >
                {

                    ({ values, errors, handleSubmit, handleBlur, handleChange }) => (
                         <View style={styles.footer}>

                            <View>
                                <View style={styles.action}>
                                    <Icon name="mail" size={40} color="#fff" style={{ paddingTop: 12 }} />
                                    <TextInput style={styles.textInput} placeholder='Email' placeholderTextColor='#fff' onBlur={handleBlur('email')} onChangeText={handleChange('email')} value={values.email} />
                                </View>
                                <Text style={styles.errorText}>{errors.email}</Text>
 
                                {/* placeholder="Email"  */}
                                <View style={styles.action}>
                                    <Icon name="lock1" size={40} color="#fff" style={{ paddingTop: 12 }} />
                                    <TextInput style={styles.textInput} placeholder='Password' placeholderTextColor='#fff' onBlur={handleBlur('password')} onChangeText={handleChange('password')} value={values.password} />
                                 </View>
                                <Text style={styles.errorText}>{errors.password}</Text>

                            </View>

                            <View style={styles.submitbox}>
                                <TouchableOpacity onPress={handleSubmit} style={styles.submitbox}>
                                    <Text style={styles.button} color='#fff' onPress={handleSubmit}>SIGN IN</Text>
                                </TouchableOpacity>
                                <Text style={styles.link}>Forgot password?!</Text>
                            </View >
 
                         </View>
                    )
                }
             </Formik>
            <TouchableOpacity onPress={() => props.navigation.navigate('signup')}>
                 <Text style={styles.link}>Don't have an account?! Sign up now</Text>
            </TouchableOpacity> 
        </View>
    )
}

 const styles = StyleSheet.create({

    container: {
         flex: 1,
        justifyContent: 'space-between',
        alignItems: 'center',
        backgroundColor: '#729fcf',
     },
    logoBox: {
        alignItems: 'center',
        width: '50%',
     },

    footer: {
        width: '80%',
         alignItems: 'center'
     },
    submitbox: {
        width: '100%',
         justifyContent: 'center',
        alignItems: 'center',
        marginTop: 170,
     },
    action: {
        flexDirection: 'row',
         justifyContent: 'center',
        borderBottomWidth: 2,
        borderColor: '#fff',
     },
    textInput: {
        justifyContent: 'center',
        marginTop: 10,
        fontSize: 20,
        width: '80%',
        color: '#fff',
     },
    button: {
        borderRadius: 50,
        backgroundColor: '#285ca0',
        color: '#fff',
        marginTop: 10,
        width: '90%',
        height: 50,
        fontSize: 22,
        fontWeight: 'bold',
     },
    link: {
        color: '#fff',
        paddingBottom: 20
     },
    errorText: {
        color: 'red',
     },
 })

export { SignIn };