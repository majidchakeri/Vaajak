import React from "react";
import { View, InputText, Text, StyleSheet, TouchableOpacity } from "react-native";
// import { NavigationContainer } from '@react-navigation/native';
// import { createNativeStackNavigator } from '@react-navigation/native-stack';

const PackagesScreen = ({ navigation }) => {
    return(
        <View style={StyleSheet.container}>
            <TouchableOpacity style={StyleSheet.touchView} onPress={() => navigation.navigate('login')}>
                <Text style={styles.textView}>
                    click on here !
                </Text>
            </TouchableOpacity>
            <TouchableOpacity style={StyleSheet.touchView} onPress={() => navigation.navigate('login')}>
                <Text style={styles.textView} onPress={() => navigation.navigate('PackagesScreen')}>
                    click on here !
                </Text>
            </TouchableOpacity>
        </View>
    )
}

const styles = StyleSheet.create({
    container:{
        flex:1,
        justifyContent: 'space-between',
    },
    touchView: {
        flex:3,
        flexDirection: 'row',
        borderWidth:2,
        borderColor: '#00843d',
        alignItems: 'center',
    },
    textView: {
        height:150,
        width:'50%',
        borderWidth:2,
        borderColor: '#903779',
    },
})
export default PackagesScreen;
