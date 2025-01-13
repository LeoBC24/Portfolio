DROP TABLE IF EXISTS studentgroup CASCADE;
DROP TABLE IF EXISTS teacher CASCADE;
DROP TABLE IF EXISTS student CASCADE;
DROP TABLE IF EXISTS course CASCADE;
DROP TABLE IF EXISTS grade CASCADE;

CREATE TABLE teacher(
    id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
    last_name VARCHAR(255) NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
);
CREATE TABLE studentgroup(
    id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
    name VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE student(
    id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
    last_name VARCHAR(255) NULL,
    first_name VARCHAR(255) NULL,
    birthday DATE NOT NULL,
    studentgroup_id BIGINT NOT NULL REFERENCES studentgroup(id),
    PRIMARY KEY(id)
);

CREATE TABLE course(
    id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
    name VARCHAR(255) NOT NULL,
    studentgroup_id BIGINT NOT NULL REFERENCES studentgroup(id),
    teacher_id BIGINT NOT NULL REFERENCES teacher(id),
    PRIMARY KEY(id)
);

CREATE TABLE grade(
    student_id BIGINT NOT NULL REFERENCES student(id),
    course_id BIGINT NOT NULL REFERENCES course(id),
    grade VARCHAR(255) NOT NULL CHECK (grade = 'S' OR grade = 'ES' OR grade = 'S-' OR grade = 'S+'),
    PRIMARY KEY(student_id, course_id)
);

INSERT INTO teacher(last_name, first_name)
VALUES ('Kent', 'Clark');

INSERT INTO studentgroup (name) VALUES ('Testiryhmä');

INSERT INTO student (last_name, first_name, birthday, studentgroup_id)
VALUES ('Caballero', 'Leonardo', '1988-09-04', 1);

INSERT INTO student (last_name, first_name, birthday, studentgroup_id)
VALUES ('Bigman', 'Donatello', '1998-07-07', 1);

INSERT INTO student (last_name, first_name, birthday, studentgroup_id)
VALUES ('Smallman', 'Samuel', '1968-11-22', 1);

INSERT INTO student (last_name, first_name, birthday, studentgroup_id)
VALUES ('Parker', 'Peter', '1999-12-4', 1);

INSERT INTO student (last_name, first_name, birthday, studentgroup_id)
VALUES ('Morales', 'Miles', '1968-8-6', 1);

INSERT INTO student (last_name, first_name, birthday, studentgroup_id)
VALUES ('Stark', 'Tony', '1955-3-3', 1);

INSERT INTO course(name, teacher_id, studentgroup_id)
VALUES('SQL ja tietorakenteet', 1, 1);

INSERT INTO grade (student_id, course_id, grade)
VALUES(1,1,'S+');

INSERT INTO grade (student_id, course_id, grade)
VALUES(2,1,'S-');
/* SELECT student.last_name, student.first_name, course.name, grade.grade 
FROM studentgroup JOIN student ON (student.studentgroup_id = studentgroup.id)
JOIN course ON (course.studentgroup_id = studentgroup.id)
LEFT JOIN grade ON (grade.course_id = course.id
AND grade.student_id = student.id)
WHERE studentgroup.name = 'Testiryhmä' AND course.name = 'SQL ja tietorakenteet'; */