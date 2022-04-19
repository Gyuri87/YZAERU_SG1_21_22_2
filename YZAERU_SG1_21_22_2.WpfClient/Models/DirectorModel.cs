namespace YZAERU_SG1_21_22_2.WpfClient.Models
{
    public class DirectorModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public DirectorModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
