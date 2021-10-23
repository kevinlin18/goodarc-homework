INSERT INTO master.dbo.Students (st_id,st_name,st_birthday,st_email) VALUES
	 (N'S0001',N'KK',N'1999-01-02',N'kevin@gmail.com'),
	 (N'S0002',N'陳小華',N'1999-01-02',N'kevin@gmail.com'),
	 (N'S0003',N'王小明',N'1999-01-02',N'kevin@gmail.com'),
	 (N'S0004',N'KK',N'1999-01-02',N'kevin@gmail.com'),
	 (N'S0005',N'宋小玉',N'1992-01-01',N'yu@mail.com');

INSERT INTO master.dbo.Classes (cl_id,cl_name,cl_credit,cl_location,cl_teacher) VALUES
	 (N'C101',N'英文',3,N'AA124',N'李'),
	 (N'C102',N'PE',0,N'CLA11',N'Paul'),
	 (N'C123',N'中文',3,N'AA123',N'王'),
	 (N'C201',N'計算機概論',3,N'AA124',N'李');

INSERT INTO master.dbo.StudentClass (sc_stId,sc_clId) VALUES
	 (N'S0001',N'C101'),
	 (N'S0001',N'C102'),
	 (N'S0002',N'C101'),
	 (N'S0002',N'C123'),
	 (N'S0002',N'C201'),
	 (N'S0003',N'C123'),
	 (N'S0003',N'C201'),
	 (N'S0004',N'C102'),
	 (N'S0005',N'C201');