const { DataTypes } = require("sequelize");
const sequelize = require("../utils/database");

const Vocabs = sequelize.define("vocabs", {

    id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
    },
    Vocab: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    translate: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    package_id: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    package_name: {
        type: DataTypes.STRING,
        allowNull: false,
    }
});
(async () => {
    await sequelize.sync();
    // Code here
  })();
module.exports = Vocabs;
