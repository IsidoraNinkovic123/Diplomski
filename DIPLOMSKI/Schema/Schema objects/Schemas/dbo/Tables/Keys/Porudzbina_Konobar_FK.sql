ALTER TABLE Porudzbina
    ADD CONSTRAINT Porudzbina_Konobar_FK FOREIGN KEY ( Konobar_MBR )
        REFERENCES Konobar ( MBR );