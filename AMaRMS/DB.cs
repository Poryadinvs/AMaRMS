using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AMaRMS
{
    
    public class DB
    {
        private readonly SQLiteAsyncConnection _database;
        public DB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Equipment>().Wait();
            _database.CreateTableAsync<MaintenanceSchedule>().Wait();
            _database.CreateTableAsync<MaintenanceRecord>().Wait();
            _database.CreateTableAsync<SpareParts>().Wait();
            _database.CreateTableAsync<WorkOrders>().Wait();
            _database.CreateTableAsync<Manager>().Wait();
            SeedData();
        }

        //public Task<int> SaveUserAsync(User user) => _database.InsertAsync(user);
        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password) =>
       _database.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        public Task<List<Equipment>> GetAllEquipmentAsync()
        {
            return _database.Table<Equipment>().ToListAsync();
        }

        public Task<int> SaveEquipmentAsync(Equipment equipment)
        {
            if (equipment.Id != 0)
            {
                return _database.UpdateAsync(equipment);
            }
            else
            {
                return _database.InsertAsync(equipment);
            }
        }

        public Task<int> DeleteEquipmentAsync(Equipment equipment)
        {
            return _database.DeleteAsync(equipment);
        }

        public Task<List<MaintenanceSchedule>> GetAllMaintenanceSchedulesAsync()
        {
            return _database.Table<MaintenanceSchedule>().ToListAsync();
        }

        public Task<int> SaveMaintenanceScheduleAsync(MaintenanceSchedule schedule)
        {
            if (schedule.Id != 0)
            {
                return _database.UpdateAsync(schedule);
            }
            else
            {
                return _database.InsertAsync(schedule);
            }
        }

        public Task<int> UpdateMaintenanceScheduleAsync(MaintenanceSchedule schedule)
        {
            return _database.UpdateAsync(schedule);
        }

        public Task<List<MaintenanceRecord>> GetAllMaintenanceRecordsAsync()
        {
            return _database.Table<MaintenanceRecord>().ToListAsync();
        }

        public Task<int> SaveMaintenanceRecordAsync(MaintenanceRecord record)
        {
            if (record.Id != 0)
            {
                return _database.UpdateAsync(record);
            }
            else
            {
                return _database.InsertAsync(record);
            }
        }

        public Task<int> DeleteMaintenanceRecordAsync(MaintenanceRecord record)
        {
            return _database.DeleteAsync(record);
        }

        public Task<List<SpareParts>> GetAllSparePartsAsync()
        {
            return _database.Table<SpareParts>().ToListAsync();
        }

        public Task<int> SaveSparePartAsync(SpareParts part)
        {
            if (part.Id != 0)
            {
                return _database.UpdateAsync(part);
            }
            else
            {
                return _database.InsertAsync(part);
            }
        }

        public Task<int> UpdateSparePartAsync(SpareParts part)
        {
            return _database.UpdateAsync(part);
        }

        public Task<int> DeleteSparePartAsync(SpareParts part)
        {
            return _database.DeleteAsync(part);
        }

        public Task<List<WorkOrders>> GetAllWorkOrdersAsync()
        {
            return _database.Table<WorkOrders>().ToListAsync();
        }

        public Task<int> SaveWorkOrderAsync(WorkOrders order)
        {
            if (order.Id != 0)
            {
                return _database.UpdateAsync(order);
            }
            else
            {
                return _database.InsertAsync(order);
            }
        }

        public Task<int> UpdateWorkOrderAsync(WorkOrders order)
        {
            return _database.UpdateAsync(order);
        }

        public Task<int> DeleteWorkOrderAsync(WorkOrders order)
        {
            return _database.DeleteAsync(order);
        }

        public async void SeedData()
        {
            // Добавляем одного менеджера
            if (await _database.Table<Manager>().CountAsync() == 0)
            {
                var manager = new Manager
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Email = "ivanov@example.com",
                    Password = "password123"
                };
                await SaveManagerAsync(manager);
            }

        }

        // Методы для работы с таблицей User
        public Task<List<User>> GetAllUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(string login, string password)
        {
            return _database.Table<User>().FirstOrDefaultAsync(u => u.Email == login && u.Password == password);
        }

        

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        // Методы для работы с таблицей Manager
        public Task<List<Manager>> GetAllManagersAsync()
        {
            return _database.Table<Manager>().ToListAsync();
        }

        public Task<Manager> GetManagerAsync(string email, string password)
        {
            return _database.Table<Manager>().FirstOrDefaultAsync(m => m.Email == email && m.Password == password);
        }

        public Task<int> SaveManagerAsync(Manager manager)
        {
            if (manager.Id != 0)
            {
                return _database.UpdateAsync(manager);
            }
            else
            {
                return _database.InsertAsync(manager);
            }
        }

        public Task<int> DeleteManagerAsync(Manager manager)
        {
            return _database.DeleteAsync(manager);
        }

        // Методы для работы с таблицей User
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        // Методы для работы с таблицей Manager
        public Task<List<Manager>> GetManagersAsync()
        {
            return _database.Table<Manager>().ToListAsync();
        }
    }
}
