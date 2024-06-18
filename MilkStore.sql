Create database MilkStore;
USE `MilkStore`
;
/****** Object:  Table `Admin`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Admin`(
	`AdminId` int AUTO_INCREMENT NOT NULL,
	`UserId` int NOT NULL,
	`Desciption` varchar(50) NULL,
 CONSTRAINT `PK_Admin` PRIMARY KEY 
(
	`AdminId` ASC
)
)
;
/****** Object:  Table `Brand`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Brand`(
	`BrandId` int AUTO_INCREMENT NOT NULL,
	`BrandName` varchar(50) NOT NULL,
    `Picture` varchar(500) NULL,
 CONSTRAINT `PK_Brand` PRIMARY KEY 
(
	`BrandId` ASC
)
)
;
/****** Object:  Table `Comment`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Comment`(
	`CommentId` int AUTO_INCREMENT NOT NULL,
	`MemberId` int NOT NULL,
	`DateCreate` datetime NOT NULL,
	`Content` varchar(500) NOT NULL,
	`Rate` double NOT NULL,
	`MilkId` int NOT NULL,
 CONSTRAINT `PK_Comment` PRIMARY KEY 
(
	`CommentId` ASC
)
)
;
/****** Object:  Table `Member`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Member`(
	`MemberId` int AUTO_INCREMENT NOT NULL,
	`UserId` int NOT NULL,
	`Desciption` varchar(50) NULL,
 CONSTRAINT `PK_Member` PRIMARY KEY 
(
	`MemberId` ASC
)
)
;
/****** Object:  Table `Milk`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Milk`(
	`MilkId` int AUTO_INCREMENT NOT NULL,
	`MilkName` varchar(150) NOT NULL,
	`BrandId` int NOT NULL,
	`Capacity` varchar(20) NULL,
	`MilkTypeId` int NOT NULL,
	`AppropriateAge` varchar(50) NULL,
	`StorageInstructions` varchar(300) NULL,
	`Price` double NOT NULL,
	`Discount` double NOT NULL,
 CONSTRAINT `PK_Milk` PRIMARY KEY 
(
	`MilkId` ASC
)
)
;
/****** Object:  Table `MilkPicture`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `MilkPicture`(
	`MilkPictureId` int AUTO_INCREMENT NOT NULL,
	`MilkId` int NOT NULL,
	`Picture` varchar(500) NULL,
 CONSTRAINT `PK_MilkPicture` PRIMARY KEY 
(
	`MilkPictureId` ASC
)
)
;

/*******      *********/
CREATE TABLE `CommentPicture`(
	`CommentPictureId` int AUTO_INCREMENT NOT NULL,
	`CommentId` int NOT NULL,
	`Picture` varchar(500) NULL,
 CONSTRAINT `PK_CommentPicture` PRIMARY KEY 
(
	`CommentPictureId` ASC
)
)
;
/****** Object:  Table `MilkType`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `MilkType`(
	`MilkTypeId` int AUTO_INCREMENT NOT NULL,
	`TypeName` varchar(50) NOT NULL,
 CONSTRAINT `PK_MilkType` PRIMARY KEY 
(
	`MilkTypeId` ASC
)
)
;
/****** Object:  Table `Order`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Order`(
	`OrderId` int AUTO_INCREMENT NOT NULL,
	`MemberId` int NOT NULL,
	`VoucherId` int NOT NULL,
	`DateCreate` datetime NOT NULL,
	`Amount` double NOT NULL,
	`OrderStatus` varchar(20) NOT NULL,
 CONSTRAINT `PK_OrderDetail` PRIMARY KEY 
(
	`OrderId` ASC
)
)
;
/****** Object:  Table `OrderDetail`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `OrderDetail`(
	`OrderDetailId` int AUTO_INCREMENT NOT NULL,
	`OrderId` int NOT NULL,
	`MilkId` int NOT NULL,
	`Quantity` int NOT NULL,
	`Total` double NOT NULL,
 CONSTRAINT `PK_Cart` PRIMARY KEY 
(
	`OrderDetailId` ASC
)
)
;
/****** Object:  Table `Role`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Role`(
	`RoleId` int AUTO_INCREMENT NOT NULL,
	`RoleName` varchar(20) NOT NULL,
 CONSTRAINT `PK_Role` PRIMARY KEY 
(
	`RoleId` ASC
)
)
;
/****** Object:  Table `Staff`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Staff`(
	`StaffId` int AUTO_INCREMENT NOT NULL,
	`UserId` int NOT NULL,
	`Desciption` varchar(100) NULL,
 CONSTRAINT `PK_Staff` PRIMARY KEY 
(
	`StaffId` ASC
)
)
;
/****** Object:  Table `User`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `User`(
	`UserId` int AUTO_INCREMENT NOT NULL,
	`UserName` varchar(20) NOT NULL,
	`Phone` varchar(10) NOT NULL,
	`DateOfBirth` datetime NOT NULL,
	`Gender` varchar(10) NOT NULL,
	`Address` varchar(100) NOT NULL,
	`RoleId` int NOT NULL,
	`ProfilePicture` varchar(500) NOT NULL,
	`DateCreate` datetime NOT NULL,
 CONSTRAINT `PK_User` PRIMARY KEY 
(
	`UserId` ASC
)
)
;
/****** Object:  Table `Voucher`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `Voucher`(
	`VoucherId` int AUTO_INCREMENT NOT NULL,
	`Title` varchar(50) NOT NULL,
	`StartDate` datetime NOT NULL,
	`EndDate` datetime NOT NULL,
	`Discount` double NOT NULL,
	`Quantity` int NOT NULL,
	`Status` varchar(20) NOT NULL,
 CONSTRAINT `PK_Voucher` PRIMARY KEY 
(
	`VoucherId` ASC
)
)
;
INSERT INTO `Brand` (`BrandName`) VALUES ('TH');

INSERT INTO `Comment` (`MemberId`, `DateCreate`, `Content`, `Rate`, `MilkId`) VALUES (2, '2024-05-09 14:56:18', 'helo', 1, 2);

INSERT INTO `CommentPicture` (`CommentId`, `Picture`) VALUES (3,'String');

INSERT INTO `Member` (`UserId`, `Desciption`) VALUES (2, 'User');

INSERT INTO `Milk` (`MilkName`, `BrandId`, `Capacity`, `MilkTypeId`, `AppropriateAge`, `StorageInstructions`, `Price`, `Discount`) VALUES ('Sua', 1, 120, 1, '12', 'string', 10000, 0.2);

INSERT INTO `MilkPicture` (`MilkId`, `Picture`) VALUES (2, 'hehe');

INSERT INTO `MilkType` (`TypeName`) VALUES ('Sua Chua');
INSERT INTO `MilkType` (`TypeName`) VALUES ('string');

INSERT INTO `Order` (`MemberId`, `VoucherId`, `DateCreate`, `Amount`, `OrderStatus`) VALUES (2, 1, '2024-06-10 14:29:54', 0, 'string');

INSERT INTO `OrderDetail` (`OrderId`, `MilkId`, `Quantity`, `Total`) VALUES (1, 2, 10, 1000);

INSERT INTO `Role` (`RoleName`) VALUES ('Admin');
INSERT INTO `Role` (`RoleName`) VALUES ('Staff');
INSERT INTO `Role` (`RoleName`) VALUES ('Member');

INSERT INTO `User` (`UserName`, `Phone`, `DateOfBirth`, `Gender`, `Address`, `RoleId`, `ProfilePicture`, `DateCreate`) VALUES ('Nhan', '123456', '2003-09-25', 'Nam', 'abc', 3, 'string', '2024-06-05');
INSERT INTO `User` (`UserName`, `Phone`, `DateOfBirth`, `Gender`, `Address`, `RoleId`, `ProfilePicture`, `DateCreate`) VALUES ('Kha', '123231', '2024-06-10 14:22:14', 'string', 'string', 1, 'string', '2024-06-10 14:22:14');

INSERT INTO `Voucher` (`Title`, `StartDate`, `EndDate`, `Discount`, `Quantity`, `Status`) VALUES ('string', '2024-06-09 14:32:04', '2024-06-09 14:32:04', 0, 1, 'string');
INSERT INTO `Voucher` (`Title`, `StartDate`, `EndDate`, `Discount`, `Quantity`, `Status`) VALUES ('string', '2024-06-10 14:19:26', '2024-06-10 14:19:26', 0, 0, 'string');
ALTER TABLE `Admin` ADD CONSTRAINT `FK_Admin_User` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`);

ALTER TABLE `Comment` ADD CONSTRAINT `FK_Comment_Member` FOREIGN KEY (`MemberId`) REFERENCES `Member` (`MemberId`);
ALTER TABLE `Comment` ADD CONSTRAINT `FK_Comment_Milk` FOREIGN KEY (`MilkId`) REFERENCES `Milk` (`MilkId`);

ALTER TABLE `Member` ADD CONSTRAINT `FK_Member_User` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`);

ALTER TABLE `Milk` ADD CONSTRAINT `FK_Milk_Brand` FOREIGN KEY (`BrandId`) REFERENCES `Brand` (`BrandId`);
ALTER TABLE `Milk` ADD CONSTRAINT `FK_Milk_MilkType` FOREIGN KEY (`MilkTypeId`) REFERENCES `MilkType` (`MilkTypeId`);

ALTER TABLE `MilkPicture` ADD CONSTRAINT `FK_MilkPicture_Milk` FOREIGN KEY (`MilkId`) REFERENCES `Milk` (`MilkId`);

ALTER TABLE `CommentPicture` ADD CONSTRAINT `FK_CommentPicture_Comment` FOREIGN KEY (`CommentId`) REFERENCES `Comment` (`CommentId`);

ALTER TABLE `Order` ADD CONSTRAINT `FK_Order_Member` FOREIGN KEY (`MemberId`) REFERENCES `Member` (`MemberId`);
ALTER TABLE `Order` ADD CONSTRAINT `FK_Order_Voucher` FOREIGN KEY (`VoucherId`) REFERENCES `Voucher` (`VoucherId`);

ALTER TABLE `OrderDetail` ADD CONSTRAINT `FK_OrderDetail_Milk` FOREIGN KEY (`MilkId`) REFERENCES `Milk` (`MilkId`);
ALTER TABLE `OrderDetail` ADD CONSTRAINT `FK_OrderDetail_Order` FOREIGN KEY (`OrderId`) REFERENCES `Order` (`OrderId`);

ALTER TABLE `Staff` ADD CONSTRAINT `FK_Staff_User` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`);

ALTER TABLE `User` ADD CONSTRAINT `FK_User_Role` FOREIGN KEY (`RoleId`) REFERENCES `Role` (`RoleId`);