namespace TodoListWebApi.Domain.Dtos
{
    public class TodoDto
    {
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}