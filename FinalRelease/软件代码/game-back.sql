-- MySQL dump 10.13  Distrib 8.3.0, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: game_projecct
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `user_pass`
--

DROP TABLE IF EXISTS `user_pass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_pass` (
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `phone` varchar(11) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_pass`
--

LOCK TABLES `user_pass` WRITE;
/*!40000 ALTER TABLE `user_pass` DISABLE KEYS */;
INSERT INTO `user_pass` VALUES ('1515','222','',''),('code_egg','789012','',''),('juliano','123456','',''),('juliano1','12345','',''),('new_player','asdbcv','',''),('Qawd','123456','we@qq.com','12323421234'),('Qwe','123456','2@qq.com','13242134231'),('Qweqwe','123','qw@qq.com','12321232123'),('Qweqweqwe','123456','1@qq.com','12321222123'),('Qwrwarawrw','123','123@qq.com','12423123421'),('random','123456','correct@qq.com','12345678901'),('Sewanglixaing','123456','',''),('Sewlx','123456','',''),('Sysysysys','123456','',''),('Zxc','1','12@qq.com','12312312312');
/*!40000 ALTER TABLE `user_pass` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_recordl`
--

DROP TABLE IF EXISTS `user_recordl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_recordl` (
  `username` varchar(20) NOT NULL,
  `record` int NOT NULL,
  `eleft` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_recordl`
--

LOCK TABLES `user_recordl` WRITE;
/*!40000 ALTER TABLE `user_recordl` DISABLE KEYS */;
INSERT INTO `user_recordl` VALUES ('juliano',5,100),('juliano',5,200),('code_egg',3,50),('code_egg',5,100),('new_player',4,300),('juliano',5,6),('juliano',5,6),('juliano',5,6),('Sysysysys',1,0),('sewlx',1,120),('sewlx',2,10),('sewlx',2,4),('Sewanglixaing',4,0),('juliano',4,0),('juliano',1,0);
/*!40000 ALTER TABLE `user_recordl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_records`
--

DROP TABLE IF EXISTS `user_records`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_records` (
  `username` varchar(20) NOT NULL,
  `record` int NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_records`
--

LOCK TABLES `user_records` WRITE;
/*!40000 ALTER TABLE `user_records` DISABLE KEYS */;
INSERT INTO `user_records` VALUES ('juliano',500,'2024-05-21 19:06:55'),('juliano',1000,'2024-04-26 19:07:22'),('juliano',2000,'2024-04-26 19:07:25'),('code_egg',1500,'2024-04-26 19:07:27'),('new_player',2000,'2024-04-26 19:07:30'),('juliano111',7,'2024-05-03 23:31:37'),('juliano111',39,'2024-05-06 21:23:14'),('juliano111',28,'2024-05-07 15:31:14'),('Sysysysys',46,'2024-05-09 20:55:19'),('juliano',70,'2024-05-09 21:38:58'),('sewlx',153,'2024-05-15 16:27:29'),('Sewanglixaing',61,'2024-05-15 17:05:18'),('juliano',10000,'2023-12-31 23:59:59'),('juliano',0,'2024-06-19 15:56:53'),('juliano',0,'2024-06-19 19:44:55'),('juliano',0,'2024-06-19 20:33:57');
/*!40000 ALTER TABLE `user_records` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-19 20:59:22
