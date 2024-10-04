﻿using _420DA3_Demo_Iterative.Business.Domain;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _420DA3_Demo_Iterative.DataAccess.DAOs;
internal class CoursDAO {
    public const string DB_TABLE_NAME = "Cours";
    public const string COURS_ETUDIANT_PIVOT_TABLE = "CoursEtudiants";

    private readonly DataTable table;
    private readonly SqlConnection connection;
    private readonly SqlDataAdapter dataAdapter;

    public CoursDAO() {
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
            $"(CodeCours, Titre) " +
            $"VALUES (@codeCours, @titre);";

        _ = insertCommand.Parameters.Add("@codeCours", SqlDbType.NVarChar, Cours.MAX_LENGTH_COURSECODE, "CodeCours");
        _ = insertCommand.Parameters.Add("@titre", SqlDbType.NVarChar, Cours.MAX_LENGTH_TITLE, "Titre");

        SqlCommand updateCommand = this.connection.CreateCommand();
        updateCommand.CommandText = $"UPDATE {DB_TABLE_NAME} " +
        $"SET CodeCours = @codeCours, " +
        $"Titre = @titre " +
        $"WHERE Id = @id " +
        $"AND CodeCours = @oldCodeCours " +
        $"AND Titre = @oldTitre;";

        _ = updateCommand.Parameters.Add("@codeCours", SqlDbType.NVarChar, Cours.MAX_LENGTH_COURSECODE, "CodeCours");
        _ = updateCommand.Parameters.Add("@titre", SqlDbType.NVarChar, Cours.MAX_LENGTH_TITLE, "Titre");
        _ = updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
        updateCommand.Parameters.Add("@oldCodeCours", SqlDbType.NVarChar, Cours.MAX_LENGTH_COURSECODE, "CodeCours").SourceVersion = DataRowVersion.Original;
        updateCommand.Parameters.Add("@oldTitre", SqlDbType.NVarChar, Cours.MAX_LENGTH_TITLE, "Titre").SourceVersion = DataRowVersion.Original;

        SqlCommand deleteCommand = this.connection.CreateCommand();
        deleteCommand.CommandText = $"DELETE FROM {DB_TABLE_NAME} WHERE Id = @id;";
        _ = deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");

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
        _ = this.dataAdapter.Fill(this.table);
    }

    public void SaveChanges() {
        if (this.connection.State != ConnectionState.Open) {
            this.connection.Open();
        }
        _ = this.dataAdapter.Update(this.table);
    }


    /*

    public Cours Create(Cours initialDto, SqlTransaction? transaction = null) {
        string query = $"INSERT INTO {DB_TABLE_NAME} (CodeCours, Titre) VALUES (@codeCours, @titre); SELECT SCOPE_IDENTITY();";

        SqlConnection conn;
        if (transaction == null) {
            conn = SqlServerConnectionProvider.GetConnection();
        } else {
            conn = transaction.Connection;
        }

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;

        SqlParameter paramCodeCours = cmd.CreateParameter();
        paramCodeCours.ParameterName = "@codeCours";
        paramCodeCours.DbType = DbType.String;
        paramCodeCours.Value = initialDto.CodeCours;
        _ = cmd.Parameters.Add(paramCodeCours);

        SqlParameter paramTitre = cmd.CreateParameter();
        paramTitre.ParameterName = "@titre";
        paramTitre.DbType = DbType.String;
        paramTitre.Value = initialDto.Titre;
        _ = cmd.Parameters.Add(paramTitre);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }


        int insertedId = (int) cmd.ExecuteScalar();

        return this.GetById(insertedId, transaction);
    }

    public Cours GetById(int id, SqlTransaction? transaction = null) {
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
        string codeCours = reader.GetString(1);
        string titre = reader.GetString(2);
        DateTime dateCreation = reader.GetDateTime(3);
        DateTime? dateModification = reader.GetValue(4) == DBNull.Value ? null : reader.GetDateTime(4);
        DateTime? dateSuppression = reader.GetValue(5) == DBNull.Value ? null : reader.GetDateTime(5);
        reader.Close();

        return new Cours(db_id, codeCours, titre, dateCreation, dateModification, dateSuppression);
    }

    public Cours Update(Cours dto, SqlTransaction? transaction = null) {
        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = $"UPDATE {DB_TABLE_NAME} SET CodeCours = @codeCours, Titre = @titre WHERE Id = @id;";

        SqlParameter paramCodeCours = cmd.CreateParameter();
        paramCodeCours.ParameterName = "@codeCours";
        paramCodeCours.DbType = DbType.String;
        paramCodeCours.Value = dto.CodeCours;
        _ = cmd.Parameters.Add(paramCodeCours);

        SqlParameter paramTitre = cmd.CreateParameter();
        paramTitre.ParameterName = "@titre";
        paramTitre.DbType = DbType.String;
        paramTitre.Value = dto.Titre;
        _ = cmd.Parameters.Add(paramTitre);

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

    public void Delete(Cours dto, SqlTransaction? transaction = null) {
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

    public List<Cours> GetByEtudiantId(int idEtudiant, SqlTransaction? transaction = null) {
        string query = $"SELECT c.* FROM {COURS_ETUDIANT_PIVOT_TABLE} cept " +
            $"JOIN {DB_TABLE_NAME} c " +
            $"ON cept.coursId = c.Id " +
            $"WHERE cept.etudiantId = @id;";


        SqlConnection conn = transaction?.Connection ?? SqlServerConnectionProvider.GetConnection();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = query;

        SqlParameter paramId = cmd.CreateParameter();
        paramId.ParameterName = "@id";
        paramId.DbType = DbType.Int32;
        paramId.Value = idEtudiant;
        _ = cmd.Parameters.Add(paramId);

        if (transaction != null) {
            cmd.Transaction = transaction;
        }

        if (conn.State != System.Data.ConnectionState.Open) {
            conn.Open();
        }

        List<Cours> resultats = new List<Cours>();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            int db_id = reader.GetInt32(0);
            string codeCours = reader.GetString(1);
            string titre = reader.GetString(2);
            DateTime dateCreation = reader.GetDateTime(3);
            DateTime? dateModification = reader.GetValue(4) == DBNull.Value ? null : reader.GetDateTime(4);
            DateTime? dateSuppression = reader.GetValue(5) == DBNull.Value ? null : reader.GetDateTime(5);
            Cours cours = new Cours(db_id, codeCours, titre, dateCreation, dateModification, dateSuppression);
            resultats.Add(cours);
        }

        reader.Close();

        return resultats;

    }
    */

}
