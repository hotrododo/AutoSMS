CREATE DATABASE  IF NOT EXISTS `hoso2018` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `hoso2018`;
-- MySQL dump 10.13  Distrib 5.7.20, for Win64 (x86_64)
--
-- Host: localhost    Database: hoso2018
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ds2018`
--

DROP TABLE IF EXISTS `ds2018`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ds2018` (
  `ID` int(11) NOT NULL,
  `Tên người nộp` varchar(60) NOT NULL,
  `Số điện thoại` varchar(12) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Ngày nộp` date NOT NULL,
  `Ngày trả` date DEFAULT NULL,
  `Hoàn thành` tinyint(4) NOT NULL,
  `Thời gian Khung/lĩnh vực` varchar(50) NOT NULL,
  `Thời gian thực` int(11) DEFAULT NULL,
  `Đúng/trễ` int(11) DEFAULT NULL,
  `Trạng thái` int(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ds2018`
--

LOCK TABLES `ds2018` WRITE;
/*!40000 ALTER TABLE `ds2018` DISABLE KEYS */;
INSERT INTO `ds2018` VALUES (1,'Đinh Công Mạnh','0987654321','manh@gmail.com','2018-01-10','2018-01-15',1,'ĐK kết hôn',5,3,2),(2,'Trần Anh Khoa','0987123456','khoa@gmail.com','2018-01-12','2018-01-15',1,'ĐK kết hôn',3,1,2),(3,'Tống Như Quỳnh','0978587785','quynh@gmail.com','2018-01-13','2018-01-16',1,'ĐK kết hôn',3,1,2),(4,'Hoàng Mạnh Linh','0913555666','linh@gmail.com','2018-01-14',NULL,0,'ĐK kết hôn',NULL,6,1),(5,'Đỗ Thu Hà','0933667710','ha@gmail.com','2018-01-15',NULL,0,'ĐK kết hôn',NULL,5,1),(6,'Võ Chí Hoàng','0972511682','hoang.vochi@gmail.com','2018-01-15','2018-01-16',1,'HS xin việc',1,NULL,2),(7,'Vương Thừa Vũ','0982331805','vu.examp@gmail.com','2018-01-16',NULL,0,'HS xin việc',NULL,3,1);
/*!40000 ALTER TABLE `ds2018` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dslv`
--

DROP TABLE IF EXISTS `dslv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dslv` (
  `Tên lĩnh vực` varchar(45) NOT NULL,
  `Thời gian/lĩnh vực` int(11) NOT NULL,
  PRIMARY KEY (`Tên lĩnh vực`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dslv`
--

LOCK TABLES `dslv` WRITE;
/*!40000 ALTER TABLE `dslv` DISABLE KEYS */;
INSERT INTO `dslv` VALUES ('HS nhập học',3),('HS xin việc',3),('HS ĐK Hộ khẩu',4),('ĐK kết hôn',2);
/*!40000 ALTER TABLE `dslv` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-22 15:45:29
