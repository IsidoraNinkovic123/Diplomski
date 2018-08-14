ALTER TABLE Pripada
    ADD CONSTRAINT Pripada_Sastojak_FK FOREIGN KEY ( Sastojak_ID )
        REFERENCES Sastojak ( ID );