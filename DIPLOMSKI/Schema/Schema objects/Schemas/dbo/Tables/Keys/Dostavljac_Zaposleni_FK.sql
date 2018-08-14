ALTER TABLE Dostavljac
    ADD CONSTRAINT Dostavljac_Zaposleni_FK FOREIGN KEY ( MBR )
        REFERENCES Zaposleni ( MBR );