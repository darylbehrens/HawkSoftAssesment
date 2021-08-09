namespace HawkSoftAssesment.Models.Interfaces
{
    public static class RawSql
    {
        public static readonly string GetContactsById = @"SELECT 
                                                            c.FirstName,
                                                            c.LastName, 
                                                            c.Email, 
                                                            c.Address, 
                                                            c.City, 
                                                            c.State, 
                                                            c.Zipcode,
                                                            c.IsActive,
                                                            c.Id
                                                        FROM 
                                                            Contact c
                                                        WHERE 
                                                            UserId = @UserId 
                                                        AND
                                                            IsActive = 1";
                                    

        public static readonly string InsertContact = @"INSERT INTO
                                                            Contact
                                                            (
                                                                FirstName,
                                                                Lastname,
                                                                Email,
                                                                Address,
                                                                City,
                                                                State,
                                                                Zipcode,
                                                                UserId
                                                            )
                                                            VALUES
                                                            (
                                                                @FirstName,
                                                                @Lastname,
                                                                @Email,
                                                                @Address,
                                                                @City,
                                                                @State,
                                                                @Zipcode,
                                                                @UserId
                                                            );
                                                            SELECT SCOPE_IDENTITY()";

        public static readonly string DeleteContact = @"UPDATE
                                                            Contact
                                                        SET
                                                            IsActive = 0
                                                        WHERE
                                                            Id = @ContactId";

        public static readonly string UpdateContact = @"UPDATE
                                                            Contact
                                                        SET
                                                            FirstName = @FirstName,
                                                            Lastname = @LastName,
                                                            Email = @Email,
                                                            Address = @Address,
                                                            City = @City,
                                                            State = @State,
                                                            Zipcode = @Zipcode 
                                                        WHERE 
                                                            Id = @ContactId
                                                        ";
        public static readonly string GetUsers = @"SELECT Id, Name FROM [User]";
    }
}
