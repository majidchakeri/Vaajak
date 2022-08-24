const { setLocale } = require('yup');
const Yup = require('yup');

// setLocale({
//     number: {
//         min: ({ min }) => ({ })
//     }
// })
exports.userSchema = Yup.object().shape({
    name: Yup.string().min(2).max(30,"").required("name is required"),
    email: Yup.string().email("email is not valid").required("email is required"),
    username: Yup.string().min(5).max(20,"maximum for username is 20").required("username is required"),
    password: Yup.string().min(8).max(255,"maximum for username is 255").required("password is required"),
    confirmPassword: Yup.string().oneOf([Yup.ref('password'), null], 'Passwords must match')
})
