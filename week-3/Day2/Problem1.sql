CREATE DATABASE eventdb;

USE eventdb;

CREATE TABLE user_info(
	email_id VARCHAR(100) PRIMARY KEY, 
	username VARCHAR(50) not null,
	role VARCHAR(30) not null CHECK(role in('admin','participant')),
	password VARCHAR(20) not null CHECK(len(password)>=6)
);

CREATE TABLE event_details(
	event_id INT IDENTITY(100, 1) PRIMARY KEY, 
	event_name VARCHAR(50) not null,
	event_category VARCHAR(50) not null, 
	event_date DATETIME not null,
	description VARCHAR(200) null, 
	status VARCHAR(200) CHECK(status in('active', 'inactive'))
);

CREATE TABLE speakers_details(
	speaker_id INT PRIMARY KEY,
	speaker_name VARCHAR(50) not null
);

CREATE TABLE session_info(
	sessionid INT PRIMARY KEY, 
	event_id INT not null, 
	session_title VARCHAR(50) not null,
	speaker_id INT not null, 
	description VARCHAR(200) null, 
	session_start DATETIME not null,
	session_end DATETIME not null, 
	session VARCHAR(200), 
	FOREIGN KEY(event_id) REFERENCES event_details(event_id), 
	FOREIGN KEY(speaker_id) REFERENCES speakers_details(speaker_id)
);

CREATE TABLE participant_event_details(
	id INT PRIMARY KEY, 
	participant_email_id VARCHAR(100) not null, 
	event_id INT not null,
	sessionid INT not null, 
	is_attended BIT not null,
	FOREIGN KEY(participant_email_id) REFERENCES user_info(email_id), 
	FOREIGN KEY(event_id)REFERENCES event_details(event_id), 
	FOREIGN KEY(sessionid)REFERENCES session_info(sessionid)
);
