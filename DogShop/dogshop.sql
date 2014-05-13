-- Database: dogshop
--Create and seed database

-- DROP DATABASE dogshop;

CREATE DATABASE dogshop
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'English_United States.1252'
       LC_CTYPE = 'English_United States.1252'
       CONNECTION LIMIT = -1;

-- Table: dog ('public' schema)

-- DROP TABLE dog;

CREATE TABLE dog
(
  id serial NOT NULL,
  name character varying(255),
  breed character varying(255),
  is_vaccinated boolean
)
WITH (
  OIDS=FALSE
);
ALTER TABLE dog
  OWNER TO postgres;

INSERT INTO dog(
           name, breed, is_vaccinated)
    VALUES ("Spike", "Labradoodle", FALSE);

INSERT INTO dog(
           name, breed, is_vaccinated)
    VALUES ("Rover", "Dalmation", TRUE);

INSERT INTO dog(
           name, breed, is_vaccinated)
    VALUES ("Butch", "Great Dane", FALSE);

INSERT INTO dog(
           name, breed, is_vaccinated)
    VALUES ("Lucky", "Rotweiler", TRUE);
