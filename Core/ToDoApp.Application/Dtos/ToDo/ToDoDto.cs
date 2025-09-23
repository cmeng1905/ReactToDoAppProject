namespace ToDoApp.Application.Dtos.ToDo
{
    public class ToDoDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
