drop table if exists Airport;
drop table if exists Flight;
drop table if exists Aircraft;
drop table if exists AircraftType;
drop table if exists Crew;
drop table if exists CrewMember;

-- TODO: Add flight plans and flights to airports

CREATE TABLE CrewMember (
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(20) NOT NULL,
    qualification VARCHAR(20) NOT NULL,
    memberId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (memberId)
);

CREATE TABLE Crew (
    captain VARCHAR(20) NOT NULL,
    firstOfficer VARCHAR(20) NOT NULL,
    flightAttendant1 VARCHAR(20) NOT NULL,
    flightAttendant2 VARCHAR(20),
    crewId INT NOT NULL AUTO_INCREMENT,
    memberId INT NOT NULL,
    PRIMARY KEY (crewId),
    FOREIGN KEY (memberId)
        REFERENCES CrewMember (memberId)
);

CREATE TABLE AircraftType (
    model VARCHAR(10),
    aircraftTypeId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (aircraftTypeId)
);

CREATE TABLE Aircraft (
    registrationNumber DOUBLE NOT NULL,
    aircraftId INT NOT NULL AUTO_INCREMENT,
    aircraftTypeId INT NOT NULL,
    crewId INT NOT NULL,
    PRIMARY KEY (aircraftId),
    FOREIGN KEY (aircraftTypeId)
        REFERENCES AircraftType (aircraftTypeId),
    FOREIGN KEY (crewId)
        REFERENCES Crew (crewId)
);

CREATE TABLE Flight (
    flightNumber DOUBLE NOT NULL,
    originAirport VARCHAR(20),
    destinationAirport VARCHAR(20),
    scheduledTakeoff TIME,
    estinmatedTakeoff TIME,
    actualTakeoff TIME,
    scheduledTouchdown TIME,
    estimatedTouchdown TIME,
    actualTouchdown TIME,
    aircraftId INT NOT NULL,
    crewId INT NOT NULL,
    flightId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (flightId),
    FOREIGN KEY (aircraftId)
        REFERENCES Aircraft (aircraftId),
    FOREIGN KEY (crewId)
        REFERENCES Crew (crewId)
);

CREATE TABLE Airport (
    standbyCrewId INT NOT NULL,
    airportId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (airportId),
    FOREIGN KEY (standbyCrewId)
        REFERENCES Crew (crewId)
);
