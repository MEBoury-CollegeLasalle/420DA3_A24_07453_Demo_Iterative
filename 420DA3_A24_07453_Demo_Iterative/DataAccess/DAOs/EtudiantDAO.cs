using Microsoft.Data.SqlClient;
using System.Data;

namespace _420DA3_Demo_Iterative.DataAccess.DAOs;
internal class EtudiantDAO {
    public const string DB_TABLE_NAME = "Etudiants";
    public const string COURS_ETUDIANT_PIVOT_TABLE = "CoursEtudiants";

    private DataTable table;
    private SqlConnection connection;
    private SqlDataAdapter dataAdapter;

    public EtudiantDAO() {
        this.connection = SqlServerConnectionProvider.GetConnection();
        this.table = new DataTable(DB_TABLE_NAME);
        this.dataAdapter = this.CreateDataAdapter();
    }

    private SqlDataAdapter CreateDataAdapter() {

        SqlDataAdapter adapter = new SqlDataAdapter();

        SqlCommand selectCommand = this.connection.CreateCommand();
        selectCommand.CommandText = $"SELECT * FROM {DB_TABLE_NAME};";

        SqlCommand insertCommand = this.connection.CreateCommand();
        insertCommand.CommandText = $"INSERT INTO {DB_TABLE_NAME} " +
            $"(Nom, Prenom, CodePermanent, DateEnregistrement) " +
            $"VALUES (@nom, @prenom, @codePermanent, @dateEnregistrement);";

        insertCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 64, "Nom");
        insertCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 64, "Prenom");
        insertCommand.Parameters.Add("@codePermanent", SqlDbType.NVarChar, 12, "CodePermanent");
        insertCommand.Parameters.Add("@dateEnregistrement", SqlDbType.DateTime2, 7, "DateEnregistrement");

        SqlCommand updateCommand = this.connection.CreateCommand();
        updateCommand.CommandText = $"UPDATE {DB_TABLE_NAME} " +
        $"SET Nom = @nom, " +
        $"Prenom = @prenom, " +
        $"CodePermanent = @codePermanent, " +
        $"DateEnregistrement = @dateEnregistrement " +
        $"WHERE Id = @id;";

        updateCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 64, "Nom");
        updateCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 64, "Prenom");
        updateCommand.Parameters.Add("@codePermanent", SqlDbType.NVarChar, 12, "CodePermanent");
        updateCommand.Parameters.Add("@dateEnregistrement", SqlDbType.DateTime2, 7, "DateEnregistrement");
        updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");

        SqlCommand deleteCommand = this.connection.CreateCommand();
        deleteCommand.CommandText = $"DELETE FROM {DB_TABLE_NAME} WHERE Id = @id;";
        deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");

        adapter.SelectCommand = selectCommand;
        adapter.UpdateCommand = updateCommand;
        adapter.DeleteCommand = deleteCommand;
        adapter.InsertCommand = insertCommand;

        return adapter;

    }

    public DataTable GetDataTable() {
        return this.table;
    }

    public void LoadDataTable() {
        this.table.Clear();
        this.dataAdapter.Fill(this.table);
    }

    public void SaveChanges() {
        if (this.connection.State != ConnectionState.Open) {
            this.connection.Open();
        }
        this.dataAdapter.Update(this.table);
    }



    /*
    public Etudiant Create(Etudiant initialDto, SqlTransaction? transaction = null) {
        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = $"INSERT INTO {DB_TABLE_NAME} " +
            $"(Nom, Prenom, CodePermanent, DateEnregistrement) " +
            $"VALUES (@nom, @prenom, @codePermanent, @dateEnregistrement); " +
            $"SELECT SCOPE_IDENTITY();";

        SqlParameter paramNom = cmd.CreateParameter();
        paramNom.ParameterName = "@nom";
        paramNom.DbType = DbType.String;
        paramNom.Value = initialDto.Nom;
        _ = cmd.Parameters.Add(paramNom);

        SqlParameter paramPrenom = cmd.CreateParameter();
        paramPrenom.ParameterName = "@prenom";
        paramPrenom.DbType = DbType.String;
        paramPrenom.Value = initialDto.Prenom;
        _ = cmd.Parameters.Add(paramPrenom);

        SqlParameter paramCode = cmd.CreateParameter();
        paramCode.ParameterName = "@codePermanent";
        paramCode.DbType = DbType.String;
        paramCode.Value = initialDto.CodePermanent;
        _ = cmd.Parameters.Add(paramCode);

        SqlParameter paramDate = cmd.CreateParameter();
        paramDate.ParameterName = "@dateEnregistrement";
        paramDate.DbType = DbType.DateTime2;
        paramDate.Value = initialDto.DateEnregistrement;
        _ = cmd.Parameters.Add(paramDate);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }

        int insertedId = (int) cmd.ExecuteScalar();

        return this.GetById(insertedId);
    }

    public Etudiant GetById(int id, SqlTransaction? transaction = null) {
        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {DB_TABLE_NAME} WHERE Id = @id;";

        SqlParameter paramId = cmd.CreateParameter();
        paramId.ParameterName = "@id";
        paramId.DbType = DbType.Int32;
        paramId.Value = id;
        _ = cmd.Parameters.Add(paramId);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }

        SqlDataReader reader = cmd.ExecuteReader();
        if (!reader.HasRows) {
            throw new Exception($"Pas d'entrée trouvée pour id #{id} dans la base de données.");
        }

        _ = reader.Read();
        int db_id = reader.GetInt32(0);
        string nom = reader.GetString(1);
        string prenom = reader.GetString(2);
        string codePermanent = reader.GetString(3);
        DateTime dateEnregistrement = reader.GetDateTime(4);
        DateTime dateCreation = reader.GetDateTime(5);
        DateTime? dateModification = reader.GetValue(6) == DBNull.Value ? null : reader.GetDateTime(6);
        DateTime? dateSuppression = reader.GetValue(7) == DBNull.Value ? null : reader.GetDateTime(7);

        return new Etudiant(db_id, nom, prenom, codePermanent, dateEnregistrement, dateCreation, dateModification, dateSuppression);
    }

    public Etudiant Update(Etudiant dto, SqlTransaction? transaction = null) {
        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = $"UPDATE {DB_TABLE_NAME} " +
        $"SET Nom = @nom, " +
        $"Prenom = @prenom, " +
        $"CodePermanent = @codePermanent, " +
        $"DateEnregistrement = @dateEnregistrement " +
        $"WHERE Id = @id;";

        SqlParameter paramNom = cmd.CreateParameter();
        paramNom.ParameterName = "@nom";
        paramNom.DbType = DbType.String;
        paramNom.Value = dto.Nom;
        _ = cmd.Parameters.Add(paramNom);

        SqlParameter paramPrenom = cmd.CreateParameter();
        paramPrenom.ParameterName = "@prenom";
        paramPrenom.DbType = DbType.String;
        paramPrenom.Value = dto.Prenom;
        _ = cmd.Parameters.Add(paramPrenom);

        SqlParameter paramCode = cmd.CreateParameter();
        paramCode.ParameterName = "@codePermanent";
        paramCode.DbType = DbType.String;
        paramCode.Value = dto.CodePermanent;
        _ = cmd.Parameters.Add(paramCode);

        SqlParameter paramDate = cmd.CreateParameter();
        paramDate.ParameterName = "@dateEnregistrement";
        paramDate.DbType = DbType.DateTime2;
        paramDate.Value = dto.DateEnregistrement;
        _ = cmd.Parameters.Add(paramDate);

        SqlParameter paramId = cmd.CreateParameter();
        paramId.ParameterName = "@id";
        paramId.DbType = DbType.Int32;
        paramId.Value = dto.Id;
        _ = cmd.Parameters.Add(paramId);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }

        int affectedRows = cmd.ExecuteNonQuery();

        // TODO: valider qu'une et une seule ligne a été modifiée

        return this.GetById(dto.Id);

    }

    public void Delete(Etudiant dto, SqlTransaction? transaction = null) {
        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = $"DELETE FROM {DB_TABLE_NAME} WHERE Id = @id;";

        SqlParameter paramId = cmd.CreateParameter();
        paramId.ParameterName = "@id";
        paramId.DbType = DbType.Int32;
        paramId.Value = dto.Id;
        _ = cmd.Parameters.Add(paramId);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }

        int affectedRows = cmd.ExecuteNonQuery();

        // TODO: valider qu'une et une seule ligne a été supprimer

    }


    public List<Etudiant> GetByCoursId(int idCours, SqlTransaction? transaction = null) {
        string query = $"SELECT c.* FROM {COURS_ETUDIANT_PIVOT_TABLE} cept " +
            $"JOIN {DB_TABLE_NAME} e " +
            $"ON cept.etudiantId = e.Id " +
            $"WHERE cept.coursId = @id;";


        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = query;

        SqlParameter paramId = cmd.CreateParameter();
        paramId.ParameterName = "@id";
        paramId.DbType = DbType.Int32;
        paramId.Value = idCours;
        _ = cmd.Parameters.Add(paramId);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }

        List<Etudiant> resultats = new List<Etudiant>();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            int db_id = reader.GetInt32(0);
            string nom = reader.GetString(1);
            string prenom = reader.GetString(2);
            string codePermanent = reader.GetString(3);
            DateTime dateEnregistrement = reader.GetDateTime(4);
            DateTime dateCreation = reader.GetDateTime(5);
            DateTime? dateModification = reader.GetValue(6) == DBNull.Value ? null : reader.GetDateTime(6);
            DateTime? dateSuppression = reader.GetValue(7) == DBNull.Value ? null : reader.GetDateTime(7);

            Etudiant etudiant = new Etudiant(db_id, nom, prenom, codePermanent, dateEnregistrement, dateCreation, dateModification, dateSuppression);
            resultats.Add(etudiant);
        }

        reader.Close();

        return resultats;

    }
    */
}
