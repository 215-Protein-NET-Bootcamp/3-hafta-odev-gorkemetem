﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HomeworkApi.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperDbContext _dbContext;

        public DepartmentRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var sql = "SELECT * FROM dbo.country";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Department>(sql);
                return result;
            }
        }

        public async Task<Department> GetByIdAsync(int entityId)
        {
            var query = "SELECT * FROM dbo.country WHERE id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Department>(query, new { entityId });
                return result;
            }
        }

        public async Task InsertAsync(Department entity)
        {
            var query = "INSERT INTO dbo.country (DepartmentId, DeptName, CountryId) " +
                "VALUES (@DepartmentId, @DeptName, @CountryId)";

            var parameters = new DynamicParameters();
            parameters.Add("departmentid", entity.DepartmentId, DbType.Int64);
            parameters.Add("deptname", entity.DeptName, DbType.String);
            parameters.Add("countryid", entity.CountryId, DbType.Int64);

            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void RemoveAsync(Department entity)
        {
            var query = "DELETE FROM dbo.country WHERE id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new { entity.CountryId });
            }
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
