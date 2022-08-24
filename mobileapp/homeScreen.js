import React from "react";
import { View, InputText, Text, StyleSheet, TouchableOpacity } from "react-native";
// import { NavigationContainer } from '@react-navigation/native';
// import { createNativeStackNavigator } from '@react-navigation/native-stack';

const Home = ({ navigation }) => {
    return(
        <View style={styles.container}>
            <View style={styles.rowBox}>
                <TouchableOpacity style={styles.touchView} onPress={() => navigation.navigate('login')}>
                    <Text style={styles.textView}>
                        Login Page!
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity style={styles.touchView} onPress={() => navigation.navigate('packages')}>
                    <Text style={styles.textView}>
                        See all packages.
                    </Text>
                </TouchableOpacity>
            </View>
            <View style={styles.rowBox}>
                <TouchableOpacity style={styles.touchView} onPress={() => navigation.navigate('login')}>
                    <Text style={styles.textView}>
                        Login Page!
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity style={styles.touchView} onPress={() => navigation.navigate('packages')}>
                    <Text style={styles.textView}>
                        See all packages.
                    </Text>
                </TouchableOpacity>
            </View>

        </View>
    )
}

const styles = StyleSheet.create({
    container:{
        flex: 1,
        flexDirection: 'column',
        flexWrap: 'wrap',
        justifyContent:'space-evenly',
        alignContent: 'center',
        alignItems: 'center',
        backgroundColor:'#89e9ff',
    },
    rowBox: {
        flexDirection:'row',
        width:'80%',
        
    },
    touchView: {
        flexDirection: 'row',
        borderWidth:2,
        borderColor: '#00843d',
        justifyContent:'space-evenly',
        alignContent: 'center',
        alignItems: 'center',
    },
    textView: {
        // height:150,
        width:'50%',
        borderWidth:2,
        borderColor: '#903779',
        justifyContent:'space-evenly',
        alignContent: 'center',
        alignItems: 'center',
    },
})
export default Home;
