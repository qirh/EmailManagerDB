/* INSERTS */ 


insert into [Email].[dbo].[User_Info]
values (1, 'Admin', '1156371652'),
(2, 'Saleh', '-1220323546'),
(3, 'tmp', '-842352753')

insert into [Email].[dbo].[Service_Provider]
values (20000, 'Hotmail'),
(20001, 'Gmail'),
(20002, 'KFUPM'),
(20003, 'OUTLOOK'),
(20004, 'HOTMAIL')

insert into [Email].[dbo].[Server_Info]
values(30000, 'smtp.live.com', 'SMTP', 587, 1, 0, 20000),
(30001, 'smtp.live.com', 'SMTP', 587, 1, 0, 20003),
(30002, 'smtp.live.com', 'SMTP', 587, 1, 0, 20004),
(30003, 'smtp.gmail.com', 'SMTP', 587, 1, 0, 20001),
(30004, 'smtp.kfupm.edu.sa', 'SMTP', 587, 1, 0, 20002),
(30005, 'pop.gmail.com', 'POP3', 995, 1, 0, 20001),
(30006, 'imap.gmail.com', 'IMAP', 993, 1, 0, 20001)

insert into [Email].[dbo].[Email_Account]
values (50000, '324projectsaleh@gmail.com', 'ICSKFUPMproject', null, 1, 1, 20001),
(50001, 'ics324project@gmail.com', 'JavaxMailTrail', null, 0, 1, 20001),
(50002, 'ics324projectsaleh13@hotmail.com', 'ICSKFUPMproject', null, 1, 2, 20000),
(50003, 'ics324projectsaleh@live.com', 'ICSKFUPMproject', null, 1, 2, 20000),
(50004, 'ics324projectsaleh@outlook.com', 'ICSKFUPMproject', null, 1, 2, 20000)




insert into [Email].[dbo].[Email_Message]
values (1000000,	's201040340@kfupm.edu.sa', 'TEST','VER 6', '2013-05-10 05:03:14.000', 50000, 1),
(1000001,	's201040340@kfupm.edu.sa', 'TEST','VER 6', '2013-05-10 05:03:35.000', 50000, 1),
(1000002,	's201040340@kfupm.edu.sa', 'TEST','VER 6', '2013-05-10 05:03:51.000', 50001, 0),
(1000003,	's201040340@kfupm.edu.sa;almto3@hotmail.com', 'TEST','VER 6', '2013-05-10 05:04:06.000', 50001, 0)

insert into [Email].[dbo].[Sent_Email]
values (1000000, 0, 1),
(1000001, 0, 0),
(1000002, 1, 1),
(1000003, 1, 0)


/* Delete */
delete from [Email].[dbo].[Email_Account]
where Email_ID = 50000