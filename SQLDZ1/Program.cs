using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDZ1
{
    class Program
    {
        SqlConnection conn = null;

        public Program()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.SelectAll();
            pr.SelectAllName();
            pr.SelectAllColor();
            pr.SelectMaxCal();
            pr.SelectMinCal();
            pr.SelectSredCal();
            pr.SelectKolFruits();
            pr.SelectKolVegetables();
            pr.SelectForColor();
            pr.SelectSpecColor();
            pr.SelectSpecKalUp(); 
            pr.SelectSpecKalDown();
            pr.SelectSpecKalRange();
            pr.SelectColorYelAndRed(); 
        }

        public void SelectAll()
        {
            SqlDataReader rdr = null;
            Console.WriteLine("Отображение всей информации из таблицы с овощами и фруктами:");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();

                int line = 0;

                do
                {
                    while (rdr.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                Console.Write(rdr.GetName(i).ToString() + "\t" + "\t");
                            }

                            Console.WriteLine();
                        }
                        line++;
                        Console.WriteLine(rdr[0] + "\t\t" + rdr[1] + "\t\t" + rdr[2] + "\t\t" + rdr[3] + "\t\t" + rdr[4]);
                    }

                } while (rdr.NextResult());

            }
            finally
            {
                if(rdr != null)
                {
                   rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectAllName()
        {
            Console.WriteLine("Отображение всех названий овощей и фруктов:");

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();



                List<string> NameDop = new List<string>();
                do
                {

                    while (rdr.Read())
                    {

                        int dop1 = 0;
                        for (int i = 0; i < NameDop.Count; i++)
                        {
                            if (rdr[1].ToString() == NameDop[i])
                            {
                                dop1++;
                            }
                        }
                        if (dop1 == 0)
                        {
                            Console.Write(rdr[1] + "     ");
                            NameDop.Add(rdr[1].ToString());
                        }

                    }
                    Console.WriteLine();
                } while (rdr.NextResult());

            
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public List<string> ShowAllColors()
        {
            SqlDataReader rdr = null;
            List<string> ColorDop = new List<string>();
            conn.Close();
            try
            {
                
                    conn.Open();
                
                
                    SqlCommand cmd1 = new SqlCommand("select * from List", conn);
                rdr = cmd1.ExecuteReader();


                
                do
                {

                    while (rdr.Read())
                    {

                        int dop = 0;
                        for (int i = 0; i < ColorDop.Count; i++)
                        {
                            if (rdr[3].ToString() == ColorDop[i])
                            {
                                dop++;
                            }
                        }
                        if (dop == 0)
                        {
                           
                            ColorDop.Add(rdr[3].ToString());
                        }

                    }
                   
                } while (rdr.NextResult());

            }
            finally
            {
                if(rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return ColorDop;
        }

        public void SelectAllColor()
        {
            Console.WriteLine("Отображение всех цветов:");
            List<string> ColorDop = new List<string>(ShowAllColors());
            SqlDataReader rdr = null;

            try
            {
                
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();


                
                do
                {
                    
                    

                        for(int i = 0; i < ColorDop.Count; i++)
                        {
                            Console.Write(ColorDop[i] + "     ");
                        }
                       
                        
                    
                    Console.WriteLine();
                } while (rdr.NextResult());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectMaxCal()
        {
            Console.Write("Максимальная калорийность:");

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                do
                {
                    int max = 0;
                    while (rdr.Read())
                    {

                        
                        
                        if (max < rdr[4].GetHashCode())
                        {
                            max = rdr[4].GetHashCode();
                        }

                    }
                    Console.WriteLine("{0}", max);
                } while (rdr.NextResult());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }


            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectMinCal()
        {
            Console.Write("Минимальная калорийность:");

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                do
                {
                    rdr.Read();
                    int min = rdr[4].GetHashCode() ;
                    while (rdr.Read())
                    {



                        if (min > rdr[4].GetHashCode())
                        {
                            min = rdr[4].GetHashCode();
                        }

                    }
                    Console.WriteLine("{0}", min);
                } while (rdr.NextResult());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }


            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }


        public void SelectSredCal()
        {
            Console.Write("Средняя калорийность:");

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                do
                {
                   
                    int avrg = 0;
                    int sum = 0;
                    int dopS = 0;
                    while (rdr.Read())
                    {


                        sum += rdr[4].GetHashCode();
                        dopS++;
                    }
                    avrg = sum / dopS;
                    Console.WriteLine("{0}", avrg);
                } while (rdr.NextResult());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }


            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }


        public void SelectKolFruits()
        {
            Console.Write("Количество фруктов:");

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
              
                int sumF = 0;
                do
                {
                    while (rdr.Read())
                    {
                        
                        
                        if (rdr[2].ToString() == "Fruit")
                        {
                            sumF++;
                        }
                    }

                } while (rdr.NextResult());
                Console.WriteLine(sumF);
                }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }


            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectKolVegetables()
        {
            Console.Write("Количество овощей:");

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                int sumV = 0;

                do
                {
                    while (rdr.Read())
                    {
                        
                    
                        if (rdr[2].ToString() == "Vegetable")
                        {
                            sumV++;
                        }
                    }

                } while (rdr.NextResult());
                Console.WriteLine(sumV);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }


            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectForColor()
        {
            List<string> ColorDop = new List<string>(ShowAllColors());
            SqlDataReader rdr = null;
         
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                int line = 0;
                
                
               

                    while (rdr.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                Console.Write(rdr.GetName(i).ToString() + "\t" + "\t");
                            }
                            line++;
                            Console.WriteLine();
                        }
                       
                    }
                   

                for (int i = 0; i < ColorDop.Count; i++)
                    {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    rdr = cmd.ExecuteReader();
                    Console.WriteLine("     " + ColorDop[i] + ":");
                        while (rdr.Read())
                        {
                            
                            
                            if (rdr[3].ToString() == ColorDop[i].ToString())
                            {
                                Console.WriteLine(rdr[0] + "\t\t" + rdr[1] + "\t\t" + rdr[2] + "\t\t" + rdr[3] + "\t\t" + rdr[4]);
                            }
                        }
                    }
                    
                    
               

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectSpecColor()
        {
            Console.WriteLine("Заданый цвет - Green");
            Console.Write("Количество овощей и фруктов заданного цвета: ");

            string DopColor = "Green";
            SqlDataReader rdr = null;
            int summ = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {


                    if (rdr[3].ToString() == DopColor)
                    {
                        summ++;
                    }
                }
                Console.WriteLine(summ);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }
        public void SelectSpecKalUp()
        {
            Console.WriteLine("Указанная калорийность - 24");
            Console.WriteLine("Овощи и фрукты с калорийностью выше указанной:");

            int DopKal = 24;
            SqlDataReader rdr = null;
           
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                int line = 0;
                while (rdr.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.Write(rdr.GetName(i).ToString() + "\t" + "\t");
                        }

                        Console.WriteLine();
                    }
                    line++;

                    if (rdr[4].GetHashCode() > DopKal)
                    {
                        Console.WriteLine(rdr[0] + "\t\t" + rdr[1] + "\t\t" + rdr[2] + "\t\t" + rdr[3] + "\t\t" + rdr[4]);
                    }
                }
                
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectSpecKalDown()
        {
            Console.WriteLine("Указанная калорийность - 24");
            Console.WriteLine("Овощи и фрукты с калорийностью ниже указанной:");

            int DopKal = 24;
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                int line = 0;
                while (rdr.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.Write(rdr.GetName(i).ToString() + "\t" + "\t");
                        }

                        Console.WriteLine();
                    }
                    line++;

                    if (rdr[4].GetHashCode() < DopKal)
                    {
                        Console.WriteLine(rdr[0] + "\t\t" + rdr[1] + "\t\t" + rdr[2] + "\t\t" + rdr[3] + "\t\t" + rdr[4]);
                    }
                }

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }

        public void SelectSpecKalRange()
        {

            {
                Console.WriteLine("Указанный диапазон: 20-30");
                Console.WriteLine("Овощи и фрукты с калорийностью в указанном диапазоне:");

                int DopKalMin = 20;
                int DopKalMax = 30;
                SqlDataReader rdr = null;

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from List", conn);
                    rdr = cmd.ExecuteReader();
                    int line = 0;
                    while (rdr.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                Console.Write(rdr.GetName(i).ToString() + "\t" + "\t");
                            }

                            Console.WriteLine();
                        }
                        line++;

                        if ((rdr[4].GetHashCode() >= DopKalMin) && (rdr[4].GetHashCode() <= DopKalMax))
                        {
                            Console.WriteLine(rdr[0] + "\t\t" + rdr[1] + "\t\t" + rdr[2] + "\t\t" + rdr[3] + "\t\t" + rdr[4]);
                        }
                    }

                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.ReadKey();
            }
        }

        public void SelectColorYelAndRed()
        {
            Console.WriteLine("Все овощи и фрукты, у которых цвет желтый ли красный: ");
            List<string> ColorDop = new List<string>();
            ColorDop.Add("Red");
            ColorDop.Add("Yellow");

            SqlDataReader rdr = null;
            int summ = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from List", conn);
                rdr = cmd.ExecuteReader();
                int line = 0;
                while (rdr.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.Write(rdr.GetName(i).ToString() + "\t" + "\t");
                        }

                        Console.WriteLine();
                    }
                    line++;
                    for (int i = 0; i < ColorDop.Count; i++)
                    {
                        if (rdr[3].ToString() == ColorDop[i])
                        {
                            Console.WriteLine(rdr[0] + "\t\t" + rdr[1] + "\t\t" + rdr[2] + "\t\t" + rdr[3] + "\t\t" + rdr[4]);
                        }
                    }
                }
                
                
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }
        public void Insert()
        {

            try
            {
                conn.Open();

                string InsertStr = @"insert into 
List ( Name, Type, Color, Calories)
values ('Pear', 'Fruit', 'Green', '20')";

                SqlCommand cmd = new SqlCommand(InsertStr, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

       
        
    }
}
