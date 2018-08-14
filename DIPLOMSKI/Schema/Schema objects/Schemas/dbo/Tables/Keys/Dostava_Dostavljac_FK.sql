ALTER TABLE Dostava
    ADD CONSTRAINT Dostava_Dostavljac_FK FOREIGN KEY ( Dostavljac_MBR )
        REFERENCES Dostavljac ( MBR );