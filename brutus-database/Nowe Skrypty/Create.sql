SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`SUBJECT`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`SUBJECT` ;

CREATE TABLE IF NOT EXISTS `mydb`.`SUBJECT` (
  `subject_id` INT NOT NULL AUTO_INCREMENT,
  `subject_name` VARCHAR(50) NOT NULL,
  `description` VARCHAR(500) NULL,
  PRIMARY KEY (`subject_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ADDRESS`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`ADDRESS` ;

CREATE TABLE IF NOT EXISTS `mydb`.`ADDRESS` (
  `address_id` INT NOT NULL AUTO_INCREMENT,
  `street` VARCHAR(75) NOT NULL,
  `building_number` VARCHAR(5) NOT NULL,
  `apartament_number` VARCHAR(5) NULL,
  `zip_code` VARCHAR(6) NOT NULL,
  `city` VARCHAR(31) NOT NULL,
  PRIMARY KEY (`address_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`LOGIN`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`LOGIN` ;

CREATE TABLE IF NOT EXISTS `mydb`.`LOGIN` (
  `login_id` INT NOT NULL,
  `login` VARCHAR(20) NULL,
  `password` VARCHAR(55) NULL,
  PRIMARY KEY (`login_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`PERSON`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`PERSON` ;

CREATE TABLE IF NOT EXISTS `mydb`.`PERSON` (
  `person_id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(20) NOT NULL,
  `last_name` VARCHAR(55) NOT NULL,
  `pesel` INT NOT NULL,
  `ADDRESS_address_id` INT NOT NULL,
  `LOGIN_login_id` INT NOT NULL,
  PRIMARY KEY (`person_id`, `ADDRESS_address_id`, `LOGIN_login_id`),
  INDEX `fk_PERSON_ADDRESS1_idx` (`ADDRESS_address_id` ASC) VISIBLE,
  INDEX `fk_PERSON_LOGIN1_idx` (`LOGIN_login_id` ASC) VISIBLE,
  CONSTRAINT `fk_PERSON_ADDRESS1`
    FOREIGN KEY (`ADDRESS_address_id`)
    REFERENCES `mydb`.`ADDRESS` (`address_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PERSON_LOGIN1`
    FOREIGN KEY (`LOGIN_login_id`)
    REFERENCES `mydb`.`LOGIN` (`login_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`TEACHER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`TEACHER` ;

CREATE TABLE IF NOT EXISTS `mydb`.`TEACHER` (
  `teacher_id` INT NOT NULL AUTO_INCREMENT,
  `PERSONS_person_id` INT NOT NULL,
  PRIMARY KEY (`teacher_id`, `PERSONS_person_id`),
  INDEX `fk_TEACHERS_PERSONS1_idx` (`PERSONS_person_id` ASC) VISIBLE,
  CONSTRAINT `fk_TEACHERS_PERSONS1`
    FOREIGN KEY (`PERSONS_person_id`)
    REFERENCES `mydb`.`PERSON` (`person_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`CLASS`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`CLASS` ;

CREATE TABLE IF NOT EXISTS `mydb`.`CLASS` (
  `class_id` INT NOT NULL AUTO_INCREMENT,
  `class_title` VARCHAR(50) NOT NULL,
  `start_year` INT NOT NULL,
  `end_year` INT NOT NULL,
  `TEACHERS_teacher_id` INT NOT NULL,
  PRIMARY KEY (`class_id`, `TEACHERS_teacher_id`),
  INDEX `fk_CLASSES_TEACHERS1_idx` (`TEACHERS_teacher_id` ASC) VISIBLE,
  CONSTRAINT `fk_CLASSES_TEACHERS1`
    FOREIGN KEY (`TEACHERS_teacher_id`)
    REFERENCES `mydb`.`TEACHER` (`teacher_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`LESSON`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`LESSON` ;

CREATE TABLE IF NOT EXISTS `mydb`.`LESSON` (
  `lesson_id` INT NOT NULL AUTO_INCREMENT,
  `SUBJECTS_subject_id` INT NOT NULL,
  `lesson_datetime` DATETIME NOT NULL,
  `topic` VARCHAR(100) NULL,
  `room` VARCHAR(4) NOT NULL,
  `CLASSES_class_id` INT NOT NULL,
  `TEACHERS_teacher_id` INT NOT NULL,
  `lesson_end` TIME NOT NULL,
  PRIMARY KEY (`lesson_id`, `SUBJECTS_subject_id`, `CLASSES_class_id`, `TEACHERS_teacher_id`),
  INDEX `fk_LESSONS_SUBJECTS_idx` (`SUBJECTS_subject_id` ASC) VISIBLE,
  INDEX `fk_LESSONS_CLASSES1_idx` (`CLASSES_class_id` ASC) VISIBLE,
  INDEX `fk_LESSONS_TEACHERS1_idx` (`TEACHERS_teacher_id` ASC) VISIBLE,
  CONSTRAINT `fk_LESSONS_SUBJECTS`
    FOREIGN KEY (`SUBJECTS_subject_id`)
    REFERENCES `mydb`.`SUBJECT` (`subject_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_LESSONS_CLASSES1`
    FOREIGN KEY (`CLASSES_class_id`)
    REFERENCES `mydb`.`CLASS` (`class_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_LESSONS_TEACHERS1`
    FOREIGN KEY (`TEACHERS_teacher_id`)
    REFERENCES `mydb`.`TEACHER` (`teacher_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`STUDENT`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`STUDENT` ;

CREATE TABLE IF NOT EXISTS `mydb`.`STUDENT` (
  `student_id` INT NOT NULL AUTO_INCREMENT,
  `PERSONS_person_id` INT NOT NULL,
  `CLASSES_class_id` INT NOT NULL,
  PRIMARY KEY (`student_id`, `PERSONS_person_id`, `CLASSES_class_id`),
  INDEX `fk_STUDENTS_PERSONS1_idx` (`PERSONS_person_id` ASC) VISIBLE,
  INDEX `fk_STUDENTS_CLASSES1_idx` (`CLASSES_class_id` ASC) VISIBLE,
  CONSTRAINT `fk_STUDENTS_PERSONS1`
    FOREIGN KEY (`PERSONS_person_id`)
    REFERENCES `mydb`.`PERSON` (`person_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_STUDENTS_CLASSES1`
    FOREIGN KEY (`CLASSES_class_id`)
    REFERENCES `mydb`.`CLASS` (`class_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`PARENT`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`PARENT` ;

CREATE TABLE IF NOT EXISTS `mydb`.`PARENT` (
  `parent_id` INT NOT NULL AUTO_INCREMENT,
  `PERSONS_person_id` INT NOT NULL,
  PRIMARY KEY (`parent_id`, `PERSONS_person_id`),
  INDEX `fk_PARENTS_PERSONS1_idx` (`PERSONS_person_id` ASC) VISIBLE,
  CONSTRAINT `fk_PARENTS_PERSONS1`
    FOREIGN KEY (`PERSONS_person_id`)
    REFERENCES `mydb`.`PERSON` (`person_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`GRADEDEF`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`GRADEDEF` ;

CREATE TABLE IF NOT EXISTS `mydb`.`GRADEDEF` (
  `gradedef_id` INT NOT NULL AUTO_INCREMENT,
  `grade` DECIMAL(3,2) NOT NULL,
  PRIMARY KEY (`gradedef_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`GRADE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`GRADE` ;

CREATE TABLE IF NOT EXISTS `mydb`.`GRADE` (
  `grade_id` INT NOT NULL AUTO_INCREMENT,
  `grade_scale` VARCHAR(45) NOT NULL,
  `grade_type` VARCHAR(10) NOT NULL,
  `GRADEDEF_gradedef_id` INT NOT NULL,
  `STUDENTS_student_id` INT NOT NULL,
  `TEACHERS_teacher_id` INT NOT NULL,
  `SUBJECTS_subject_id` INT NOT NULL,
  `grade_datetime` DATETIME NOT NULL,
  PRIMARY KEY (`grade_id`, `GRADEDEF_gradedef_id`, `STUDENTS_student_id`, `TEACHERS_teacher_id`, `SUBJECTS_subject_id`),
  INDEX `fk_GRADES_GRADEDEF1_idx` (`GRADEDEF_gradedef_id` ASC) VISIBLE,
  INDEX `fk_GRADES_STUDENTS1_idx` (`STUDENTS_student_id` ASC) VISIBLE,
  INDEX `fk_GRADES_TEACHERS1_idx` (`TEACHERS_teacher_id` ASC) VISIBLE,
  INDEX `fk_GRADES_SUBJECTS1_idx` (`SUBJECTS_subject_id` ASC) VISIBLE,
  CONSTRAINT `fk_GRADES_GRADEDEF1`
    FOREIGN KEY (`GRADEDEF_gradedef_id`)
    REFERENCES `mydb`.`GRADEDEF` (`gradedef_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GRADES_STUDENTS1`
    FOREIGN KEY (`STUDENTS_student_id`)
    REFERENCES `mydb`.`STUDENT` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GRADES_TEACHERS1`
    FOREIGN KEY (`TEACHERS_teacher_id`)
    REFERENCES `mydb`.`TEACHER` (`teacher_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GRADES_SUBJECTS1`
    FOREIGN KEY (`SUBJECTS_subject_id`)
    REFERENCES `mydb`.`SUBJECT` (`subject_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ABSENCE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`ABSENCE` ;

CREATE TABLE IF NOT EXISTS `mydb`.`ABSENCE` (
  `absence_id` INT NOT NULL AUTO_INCREMENT,
  `excused` CHAR(1) NOT NULL,
  `STUDENTS_student_id` INT NOT NULL,
  `LESSONS_lesson_id` INT NOT NULL,
  PRIMARY KEY (`absence_id`, `STUDENTS_student_id`, `LESSONS_lesson_id`),
  INDEX `fk_ABSENCES_STUDENTS1_idx` (`STUDENTS_student_id` ASC) VISIBLE,
  INDEX `fk_ABSENCES_LESSONS1_idx` (`LESSONS_lesson_id` ASC) VISIBLE,
  CONSTRAINT `fk_ABSENCES_STUDENTS1`
    FOREIGN KEY (`STUDENTS_student_id`)
    REFERENCES `mydb`.`STUDENT` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ABSENCES_LESSONS1`
    FOREIGN KEY (`LESSONS_lesson_id`)
    REFERENCES `mydb`.`LESSON` (`lesson_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`BEHAVIOR`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`BEHAVIOR` ;

CREATE TABLE IF NOT EXISTS `mydb`.`BEHAVIOR` (
  `behavior_id` INT NOT NULL AUTO_INCREMENT,
  `behavior` VARCHAR(200) NOT NULL,
  `behavior_type` VARCHAR(45) NOT NULL,
  `STUDENTS_student_id` INT NOT NULL,
  PRIMARY KEY (`behavior_id`, `STUDENTS_student_id`),
  INDEX `fk_BEHAVIORS_STUDENTS1_idx` (`STUDENTS_student_id` ASC) VISIBLE,
  CONSTRAINT `fk_BEHAVIORS_STUDENTS1`
    FOREIGN KEY (`STUDENTS_student_id`)
    REFERENCES `mydb`.`STUDENT` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`user` ;

CREATE TABLE IF NOT EXISTS `mydb`.`user` (
  `username` VARCHAR(16) NOT NULL,
  `email` VARCHAR(255) NULL,
  `password` VARCHAR(32) NOT NULL,
  `create_time` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP);


-- -----------------------------------------------------
-- Table `mydb`.`category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`category` ;

CREATE TABLE IF NOT EXISTS `mydb`.`category` (
  `category_id` INT NOT NULL,
  `name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`category_id`));


-- -----------------------------------------------------
-- Table `mydb`.`FAMILY`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`FAMILY` ;

CREATE TABLE IF NOT EXISTS `mydb`.`FAMILY` (
  `PARENTS_parent_id` INT NOT NULL,
  `STUDENTS_student_id` INT NOT NULL,
  PRIMARY KEY (`PARENTS_parent_id`, `STUDENTS_student_id`),
  INDEX `fk_FAMILY_STUDENTS1_idx` (`STUDENTS_student_id` ASC) VISIBLE,
  CONSTRAINT `fk_FAMILY_PARENTS1`
    FOREIGN KEY (`PARENTS_parent_id`)
    REFERENCES `mydb`.`PARENT` (`parent_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_FAMILY_STUDENTS1`
    FOREIGN KEY (`STUDENTS_student_id`)
    REFERENCES `mydb`.`STUDENT` (`student_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


CREATE TABLE IF NOT EXISTS GRADE_LOGS (
	
log_date TIMESTAMP,
 who varchar(50),
change_type varchar(20)
)

ENGINE = InnoDB;



CREATE TABLE IF NOT EXISTS ABSENCES_LOGS (
	
log_date TIMESTAMP,
 who varchar(50),
change_type varchar(20)
)

ENGINE = InnoDB;



CREATE TABLE IF NOT EXISTS BEHAVIORS_LOGS (
	
log_date TIMESTAMP,
 who varchar(50),
change_type varchar(20)
)


ENGINE = InnoDB;

USE `mydb` ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


-- TRIGGERS
CREATE TRIGGER T_GRADE_LOGS_I
AFTER INSERT
ON GRADE 
FOR EACH ROW
INSERT INTO GRADE_LOGS(log_date,who,change_type) VALUES(now(),'TEACHER','INSERT');

CREATE TRIGGER T_GRADE_LOGS_U
AFTER UPDATE
ON GRADE
FOR EACH ROW
INSERT INTO GRADE_LOGS(log_date,who,change_type) VALUES(now(),'TEACHER','UPDATE');   

CREATE TRIGGER T_GRADE_LOGS_D
AFTER DELETE  
ON GRADE 
FOR EACH ROW
INSERT INTO GRADE_LOGS(log_date,who,change_type) VALUES(now(),'EDUCATOR','DELETE');

CREATE TRIGGER T_ABSENCES_I
AFTER INSERT
ON ABSENCE
FOR EACH ROW
INSERT INTO ABSENCES_LOGS(log_date,who,change_type) VALUES(now(),'TEACHER','INSERT');

CREATE TRIGGER T_ABSENCES_U
AFTER DELETE  
ON ABSENCE
FOR EACH ROW
INSERT INTO ABSENCES_LOGS(log_date,who,change_type) VALUES(now(),'EDUCATOR','DELETE'); 

CREATE TRIGGER T_ABSENCES_D
AFTER UPDATE
ON ABSENCE
FOR EACH ROW  
INSERT INTO ABSENCES_LOGS(log_date,who,change_type) VALUES(now(),'EDUCATOR','UPDATE');

CREATE TRIGGER T_BEHAVIORS_I
AFTER INSERT
ON BEHAVIOR
FOR EACH ROW
INSERT INTO BEHAVIORS_LOGS(log_date,who,change_type) VALUES(now(),'TEACHER','INSERT');

CREATE TRIGGER T_BEHAVIORS_U
AFTER DELETE  
ON BEHAVIOR
FOR EACH ROW
INSERT INTO BEHAVIORS_LOGS(log_date,who,change_type) VALUES(now(),'TEACHER','DELETE'); 

CREATE TRIGGER T_BEHAVIORS_D
AFTER UPDATE
ON BEHAVIOR
FOR EACH ROW  
INSERT INTO behaviors_logs(log_date,who,change_type) VALUES(now(),'EDUCATOR','UPDATE'); 

-- VIEWS
CREATE VIEW TIMETABLE AS
SELECT s.subject_name, l.lesson_datetime, l.room, p.first_name, p.last_name
FROM LESSON l
       JOIN SUBJECT s ON l.SUBJECTS_subject_id = s.subject_id
       JOIN TEACHER t ON l.TEACHERS_teacher_id = t.teacher_id
       JOIN PERSON p ON t.PERSONS_person_id = p.person_id
WHERE CLASSES_class_id =1
ORDER BY `lesson_datetime` ASC;

CREATE VIEW TIMETABLE2 AS
SELECT s.subject_name, l.lesson_datetime, l.room, p.first_name, p.last_name
FROM LESSON l
            JOIN SUBJECT s ON l.SUBJECTS_subject_id = s.subject_id
            JOIN TEACHER t ON l.TEACHERS_teacher_id = t.teacher_id
            JOIN PERSON p ON t.PERSONS_person_id = p.person_id
WHERE CLASSES_class_id =2
ORDER BY `lesson_datetime` ASC;

CREATE VIEW ABSENCES1 AS
SELECT a.excused, l.lesson_datetime, p.first_name, p.last_name
FROM ABSENCE a
JOIN LESSON l ON a.LESSONS_lesson_id = l.lesson_id
JOIN STUDENT s ON a.STUDENTS_student_id = s.student_id
JOIN PERSON p ON s.PERSONS_person_id = p.person_id
ORDER BY `lesson_datetime` ASC;

CREATE VIEW REPORT_CARD1 AS
SELECT s.subject_name, SUM(g.grade_scale * gg.grade)/ COUNT(g.STUDENTS_student_id) AS `srednia`
FROM GRADE g
JOIN SUBJECT s ON g.SUBJECTS_subject_id = s.subject_id
JOIN STUDENT st ON g.STUDENTS_student_id = st.student_id
JOIN GRADEDEF gg ON gg.gradedef_id = g.GRADEDEF_gradedef_id
WHERE st.student_id = 1
GROUP BY `subject_name`
ORDER BY `subject_name` ASC;
