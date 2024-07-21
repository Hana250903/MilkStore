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
	`VoucherId` int NULL,
	`DateCreate` datetime NOT NULL,
	`Amount` double NOT NULL,
	`StatusId` int NOT NULL,
 CONSTRAINT `PK_Order` PRIMARY KEY 
(
	`OrderId` ASC
)
)
;

CREATE TABLE `Status` (
	`StatusId` int AUTO_INCREMENT NOT NULL,
	`Status` varchar(50) NOT NULL,
	constraint `PK_Status` primary key
    (
		`StatusId` ASC
    )
    )
    ;

/****** Object:  Table `OrderDetail`    Script Date: 15/06/2024 17:12:31 ******/


CREATE TABLE `OrderDetail`(
	`OrderDetailId` int AUTO_INCREMENT NOT NULL,
	`OrderId` int NULL,
	`MilkId` int NOT NULL,
	`Quantity` int NOT NULL,
	`Total` double NOT NULL,
 CONSTRAINT `PK_OrderDetail` PRIMARY KEY 
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
	`Phone` varchar(11) NOT NULL,
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
	`VoucherStatusId` int NOT NULL,
 CONSTRAINT `PK_Voucher` PRIMARY KEY 
(
	`VoucherId` ASC
)
)
;

CREATE TABLE `VoucherStatus` (
	`VoucherStatusId` int AUTO_INCREMENT NOT NULL,
	`VoucherStatus` varchar(50) NOT NULL,
	constraint `PK_VoucherStatus` primary key
    (
		`VoucherStatusId` ASC
    )
    )
    ;

INSERT INTO `Role` (`RoleName`) VALUES ('Admin');
INSERT INTO `Role` (`RoleName`) VALUES ('Staff');
INSERT INTO `Role` (`RoleName`) VALUES ('Member');

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
ALTER TABLE `Order` ADD CONSTRAINT `FK_Order_Status` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`StatusId`);

ALTER TABLE `OrderDetail` ADD CONSTRAINT `FK_OrderDetail_Milk` FOREIGN KEY (`MilkId`) REFERENCES `Milk` (`MilkId`);
ALTER TABLE `OrderDetail` ADD CONSTRAINT `FK_OrderDetail_Order` FOREIGN KEY (`OrderId`) REFERENCES `Order` (`OrderId`);

ALTER TABLE `Staff` ADD CONSTRAINT `FK_Staff_User` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`);

ALTER TABLE `User` ADD CONSTRAINT `FK_User_Role` FOREIGN KEY (`RoleId`) REFERENCES `Role` (`RoleId`);

ALTER TABLE `Voucher` ADD CONSTRAINT `FK_Voucher_VoucherStatus` FOREIGN KEY (`VoucherStatusId`) REFERENCES `VoucherStatus` (`VoucherStatusId`);