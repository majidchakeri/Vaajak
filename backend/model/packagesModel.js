const { DataTypes } = require("sequelize");
const sequelize = require("../utils/database");

const Package = sequelize.define("packages", {
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
    creator_id: {
        type: DataTypes.INTEGER,
        allowNull: false,
    }
});
(async () => {
    await sequelize.sync();
    // Code here
  })();
module.exports = Package;
