CREATE TABLE master.dbo.Classes (
	cl_id varchar(4) NOT NULL,
	cl_name nvarchar(20) NOT NULL,
	cl_credit int NOT NULL,
	cl_location nvarchar(20) NOT NULL,
	cl_teacher nvarchar(20) NOT NULL,
	CONSTRAINT Classes_PK PRIMARY KEY (cl_id)
);
CREATE TABLE master.dbo.Students (
	st_id varchar(5) NOT NULL,
	st_name nvarchar(20) NULL,
	st_birthday date NULL,
	st_email varchar(50) NULL,
	CONSTRAINT Students_PK PRIMARY KEY (st_id)
);
CREATE TABLE master.dbo.StudentClass (
	sc_stId varchar(5) NOT NULL,
	sc_clId varchar(4) NOT NULL,
	CONSTRAINT StudentClass_PK PRIMARY KEY (sc_stId,sc_clId),
	CONSTRAINT StudentClass_FK FOREIGN KEY (sc_clId) REFERENCES master.dbo.Classes(cl_id),
	CONSTRAINT StudentClass_FK_1 FOREIGN KEY (sc_stId) REFERENCES master.dbo.Students(st_id)
);