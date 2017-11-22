# 说明

- ## sql
1. 新建库 库名为 contacts 
2. 执行以下sql
```sql
/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : contacts

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2017-11-22 11:41:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for contacts
-- ----------------------------
DROP TABLE IF EXISTS `contacts`;
CREATE TABLE `contacts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `gender` varchar(255) DEFAULT NULL,
  `company` varchar(255) DEFAULT NULL,
  `phonenumber` varchar(255) DEFAULT NULL,
  `createdtime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of contacts
-- ----------------------------
INSERT INTO `contacts` VALUES ('2', 'liba123123', '女', '校宝', '13888521011', '2017-11-21 16:37:11');
INSERT INTO `contacts` VALUES ('4', '1', '女', 'null', '15895684214', '2017-11-21 17:10:37');
INSERT INTO `contacts` VALUES ('5', '男', '男', '校宝', '13777821015', '2017-11-21 17:11:09');
INSERT INTO `contacts` VALUES ('6', '123', '男', '123', '13777115110', '2017-11-07 17:26:55');
INSERT INTO `contacts` VALUES ('7', '123', '男', '123', '13777821012', '2017-11-30 17:27:19');

```
- ## build
进入contactfront 文件夹下
npm install
npm run build

- ## Web.config
connectionString 设置 user password 和 database
```xml
  <!--mysql连接池-->
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=aspnet-Sanlogic.MSTWebsite-20140219093639;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-Sanlogic.MSTWebsite-20140219093639.mdf" providerName="System.Data.SqlClient" />
    <add name="DBConnection" connectionString="server=localhost;user id=root;password=wlwdaybtx;database=contacts; pooling=true;" providerName="MySql.Data.MySqlClient" />
  </connectionStrings>
```
- ## 运行
