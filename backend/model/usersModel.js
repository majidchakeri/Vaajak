const { DataTypes } = require("sequelize");
const sequelize = require("../utils/database");
const bcrypt = require('bcrypt');
const { userSchema } = require("./secure/userValidation");

const User = sequelize.define("users", {
    // Model Attributes
    id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
    },
    name: {
        type: DataTypes.STRING,
        allowNull: false,
        // require: [true, 'Please enter your name'],
    },
    email: {
        type: DataTypes.STRING,
        // require: [true, 'Please provide your email'],
        unique: true,
        allowNull: false,
        lowercase: true,
        validate: {
            isEmail: true
        }
    },
    username: {
        type: DataTypes.STRING,
        unique: true,
        allowNull: false,
        validate: {
            min: 5,
        }
    },
    password: {
        type: DataTypes.STRING,
        minlength: 8,
        allowNull: false,
        validate: {
            min: 8,
        },
    },
    passwordConfirm:{
        type: DataTypes.STRING,
        //allowNull: false,
        require: [true, 'Please confirm your password'],
        validate: { pasw(val) {
            return val === this.password
            },
        }
    },
    status: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
}, {
    defaultScope: {
        attributes: { exclude: ['password'] },
    },
    scopes: {
        withPassword: {
            attributes: { },
        }
    }
});

User.beforeCreate(async (user, options) => {
    user.password = await bcrypt.hash(user.password, 12);
    this.passwordConfirm = undefined;
    // next();
});

// Adding an instance level methods.
User.prototype.comparePassword = function (password) {
    return bcrypt.compareSync(password, this.password);
};

// This line create table on database
(async () => {
    await sequelize.sync();
    // Code here
  })();
module.exports = User;
