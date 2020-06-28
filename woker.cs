using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace flowers_Ermoshina
{
    public partial class woker : Form
    {
        public woker()
        {
            InitializeComponent();
            //Создание конфиг. менеджера для работы с настройками подключения
            SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);
            //имя сервера
            string ServerName = csBuilder.DataSource;
            //имя базы данных
            string DBName = csBuilder.InitialCatalog;
            //строка подключения
            ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBName + ";Integrated Security=True";
            conn(ConnectionString, select_vid, dataGridView1);
            conn(ConnectionString, select_tovar, dataGridView2);
            conn(ConnectionString, select_supplier, dataGridView3);
            conn(ConnectionString, select_postavka, dataGridView5);
            conn(ConnectionString, select_klient, dataGridView6);
            conn(ConnectionString, select_sale, dataGridView7);
            conn2(ConnectionString, select_vid, comboBox2, "Название вида", "№ вида");
          //  conn2(ConnectionString, select_supplier, comboBox2, "Название вида", "№ вида");
            conn2(ConnectionString, sel_klient, comboBox6, "ФИО", "ID Клиента");
            conn2(ConnectionString, sel_tovar, comboBox7, "Название", "ID Товара");
            conn2(ConnectionString, sel_tovar, comboBox4, "Название", "ID Товара");
            conn2(ConnectionString, sel_tovar, cb_tovar, "Название", "ID Товара");
            conn2(ConnectionString, select_supplier, cb_supplier, "Компания", "№ поставщика");
            conn(ConnectionString, select_zakaz, dataGridView8);


            SelfRef = this;
        }

        public string ConnectionString;
        public string select_vid = "SELECT id_vid as[№ вида], NAIM_VID as[Название вида], VID as [Тип] FROM VID_TOVARA ";
        public string select_tovar = "SELECT        TOVAR.ID_TOVAR as[№ товара], TOVAR.NAIM_TOVAR as[Название], VID_TOVARA.NAIM_VID as[Вид], TOVAR.KOLVO as[Количество], TOVAR.PRICE as[Цена] FROM VID_TOVARA INNER JOIN TOVAR ON VID_TOVARA.ID_VID = TOVAR.ID_VID";
        public string select_supplier = "SELECT  id_supplier as[№ поставщика],      naim as [Компания],  adres as[Адрес], tel as [Телефон] FROM supplier";
        public string select_sale= "SELECT    id_sale as[№ продажи],      Sale.data_sale as [Дата Продажи], TOVAR.NAIM_TOVAR as [Товар], Sale.kolvo_sale as [Кол-во товара], Sale.price_sale as [Цена товара] FROM TOVAR INNER JOIN Sale ON TOVAR.ID_TOVAR = Sale.id_tovar";
        public string select_postavka = " SELECT        postavka.data_post  as [Дата Поставки], supplier.naim  as [Компания], TOVAR.NAIM_TOVAR  as [Товар], postavka.kolvo  as [Кол-во товара], postavka.price   as [Цена товара] FROM postavka INNER JOIN supplier ON postavka.id_supplier = supplier.id_supplier INNER JOIN TOVAR ON postavka.id_tovar = TOVAR.ID_TOVAR";

        public string select_klient = "select id_klient as [ID клиента], FIO_klient as [ФИО], tel as [Телефон] from klient";

        public string select_zakaz = "select  id_zakaz as [ID заказа], zakaz.data_zakaz as [Дата заказа], klient.FIO_klient as [ФИО], TOVAR.NAIM_TOVAR as[Название], zakaz.kolvo_zakaz as [кол-во], zakaz.adres_zakaz as [адрес], zakaz.plan_data as [План. дата], zakaz.fakt_data AS [Факт.дата возврата]  from zakaz, klient, tovar where zakaz.id_tovar=tovar.id_tovar and zakaz.id_klient=klient.id_klient";

        public string sel_klient = "select id_klient as [ID клиента], FIO_klient as [ФИО] from klient";

        public string sel_tovar = "SELECT ID_TOVAR as [ID Товара], NAIM_TOVAR as [Название] from tovar";
        public static woker SelfRef
        {
            get; set;
        }







        //Подключение к БД и выборка данных по запросу SELECT
        public void conn(string CS, string cmdT, DataGridView dgv)
        {
            //создание экземпляра адаптера
            SqlDataAdapter Adapter = new SqlDataAdapter(cmdT, CS);
            //создание объекта DataSet (набор данных)
            DataSet ds = new DataSet();
            //Заполнение таблицы набора данных DataSet 
            Adapter.Fill(ds, "Table");
            //Связываем источник данных компонента dataGridView на форме, с таблицей            
            dgv.DataSource = ds.Tables["Table"].DefaultView;

        }
        // выборка из таблицы 
        public void conn2(string CS, string cmdT, ComboBox CB, string field1, string field2)
        {
            //создание экземпляра адаптера
            SqlDataAdapter Adapter = new SqlDataAdapter(cmdT, CS);
            //создание объекта DataSet (набор данных)
            DataSet ds = new DataSet();
            Adapter.Fill(ds, "Table");
            // привязка ComboBox к таблице БД
            CB.DataSource = ds.Tables["Table"];

            CB.DisplayMember = field1; //установка отображаемого в списке поля
            CB.ValueMember = field2; //установка ключевого поля

        }


        private void woker_Load(object sender, EventArgs e)
        {
            label1.Text = "Сегодня " + DateTime.Now.ToShortDateString();
            label2.Text = "Время мск " + DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_vid]";
            //создаем параметр
            cmd.Parameters.Add("@naim_vid", SqlDbType.Char, 20);
            //задаем значение параметра
            cmd.Parameters["@naim_vid"].Value = textBox1.Text;
            cmd.Parameters.Add("@vid", SqlDbType.Char, 15);
            cmd.Parameters["@vid"].Value = comboBox1.Text;
          
            //Выполнение хранимой процедуры-добавление экземпляра
            cmd.ExecuteScalar();

            MessageBox.Show("Добавлена запись");
            //обновление списка книг в каталоге
            conn(ConnectionString, select_vid, dataGridView1);
            conn2(ConnectionString, select_vid, comboBox2, "Название вида", "№ вида");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_tovar]";
            //создаем параметр
            cmd.Parameters.Add("@naim_tovar", SqlDbType.Char, 50);
            //задаем значение параметра
            cmd.Parameters["@naim_tovar"].Value = textBox2.Text;
            cmd.Parameters.Add("@id_vid", SqlDbType.Char, 15);
            cmd.Parameters["@id_vid"].Value = comboBox2.SelectedValue;
            cmd.Parameters.Add("@kolvo", SqlDbType.Int);
            //задаем значение параметра
            cmd.Parameters["@kolvo"].Value = textBox3.Text;
            cmd.Parameters.Add("@price", SqlDbType.Int);
            //задаем значение параметра
            cmd.Parameters["@price"].Value = textBox4.Text;
            //Выполнение хранимой процедуры-добавление экземпляра
            cmd.ExecuteScalar();

            MessageBox.Show("Добавлена запись в таблицу Товар");
            //обновление списка книг в каталоге
            conn(ConnectionString, select_tovar, dataGridView2);
            conn2(ConnectionString, select_vid, comboBox2, "Название вида", "№ вида");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_supplier]";
            cmd.Parameters.Add("@naim", SqlDbType.Char, 20);
            cmd.Parameters["@naim"].Value = textBox7.Text;
            cmd.Parameters.Add("@adres", SqlDbType.Char, 60);
            cmd.Parameters["@adres"].Value = textBox6.Text;
            cmd.Parameters.Add("@tel", SqlDbType.Decimal, 11);
            cmd.Parameters["@tel"].Value = textBox5.Text;
            cmd.ExecuteScalar();

            MessageBox.Show("Добавлена запись в таблицу Поставщики");
            conn(ConnectionString, select_supplier, dataGridView3);
        }




        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_postavka]";
            cmd.Parameters.Add("@data_post", SqlDbType.Date);
            cmd.Parameters["data_post"].Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@kolvo_post", SqlDbType.Int);
            cmd.Parameters["@kolvo_post"].Value = textBox9.Text;
            cmd.Parameters.Add("@price_post", SqlDbType.Decimal);
            cmd.Parameters["@price_post"].Value = textBox8.Text;
            cmd.Parameters.Add("@id_supplier", SqlDbType.Int);
            cmd.Parameters["@id_supplier"].Value = cb_supplier.SelectedValue;
            cmd.Parameters.Add("@id_tovar", SqlDbType.Int);
            cmd.Parameters["@id_tovar"].Value = cb_tovar.SelectedValue;

            cmd.ExecuteScalar();

            MessageBox.Show("Добавлена запись в таблицу Поставки");
            conn(ConnectionString, select_postavka, dataGridView5);
            conn2(ConnectionString, sel_tovar, cb_tovar, "Название", "ID Товара");
            conn2(ConnectionString, select_supplier, cb_supplier, "Компания", "№ поставщика");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_klient]";
            cmd.Parameters.Add("@FIO_klient", SqlDbType.Char, 30);
            cmd.Parameters["@FIO_klient"].Value = textBox11.Text;
            cmd.Parameters.Add("@tel", SqlDbType.Int);
            cmd.Parameters["@tel"].Value = textBox10.Text;
            cmd.ExecuteScalar();
            MessageBox.Show("Добавлена запись в таблицу Клиенты");
            conn(ConnectionString, select_klient, dataGridView6);
            conn2(ConnectionString, sel_klient, comboBox6, "ФИО", "ID Клиента");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_zakaz]";
            cmd.Parameters.Add("@data_zakaz", SqlDbType.Date);
            cmd.Parameters["@data_zakaz"].Value = dateTimePicker3.Value;
            cmd.Parameters.Add("@kolvo_zakaz", SqlDbType.Int);
            cmd.Parameters["@kolvo_zakaz"].Value = textBox13.Text;
            cmd.Parameters.Add("@adres", SqlDbType.Char, 50);
            cmd.Parameters["@adres"].Value = textBox12.Text;
            cmd.Parameters.Add("@plan_data", SqlDbType.Date);
            cmd.Parameters["@plan_data"].Value = dateTimePicker4.Value;
            cmd.Parameters.Add("@id_klient", SqlDbType.Int);
            cmd.Parameters["@id_klient"].Value = comboBox6.SelectedValue;
            cmd.Parameters.Add("@id_tovar", SqlDbType.Int);
            cmd.Parameters["@id_tovar"].Value = comboBox7.SelectedValue;

            cmd.ExecuteScalar();

            MessageBox.Show("Добавлена запись в таблицу Заказ");
            conn(ConnectionString, select_zakaz, dataGridView8);
            conn2(ConnectionString, sel_tovar, comboBox7, "Название", "ID Товара");
            conn2(ConnectionString, sel_klient, comboBox6, "ФИО", "ID Клиента");
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[add_sale]";
            cmd.Parameters.Add("@date_sale", SqlDbType.Date);
            cmd.Parameters["@date_sale"].Value = dateTimePicker2.Value;
            cmd.Parameters.Add("@id_tovar", SqlDbType.Int);
            cmd.Parameters["@id_tovar"].Value = comboBox4.SelectedValue;
            cmd.Parameters.Add("@kolvo_sale", SqlDbType.Int);
            cmd.Parameters["@kolvo_sale"].Value = textBox14.Text;
            cmd.Parameters.Add("@price_sale", SqlDbType.Int);
            cmd.Parameters["@price_sale"].Value = textBox15.Text;
            cmd.ExecuteScalar();
            //обновление списка книг в каталоге
            conn(ConnectionString, select_sale, dataGridView7);
            conn2(ConnectionString, sel_tovar, comboBox4, "Название", "ID Товара");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn_q = new SqlConnection();
            conn_q.ConnectionString = woker.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn_q.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn_q.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[update_zakaz]";
            cmd.Parameters.Add("@fakt_data", SqlDbType.Date);
            cmd.Parameters["@fakt_data"].Value = dateTimePicker5.Value;
            cmd.Parameters.Add("@ID_zakaz", SqlDbType.Int, 4);
            //определяем ID книговыдачи
            string ID_zakaz = dataGridView8[0, dataGridView8.CurrentRow.Index].Value.ToString();
            //задаем значение параметра
            cmd.Parameters["@ID_zakaz"].Value = ID_zakaz;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Изменения внесены в таблицу Заказ");
            conn(ConnectionString, select_zakaz, dataGridView8);


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
    }
