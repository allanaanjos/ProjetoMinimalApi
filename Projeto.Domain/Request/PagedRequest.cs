namespace Projeto.Domain.Request
{
    public abstract class PagedRequest
    {
        private int _pageSize = 10;
        private int _pageNumber = 1;

        public int PageSize 
        {
            get => _pageSize; 
            set
            {
                if (value < 1)
                    throw new ArgumentException("O tamanho da página deve ser maior que 0.");
                _pageSize = value;
            }
        }

        public int PageNumber 
        {
            get => _pageNumber; 
            set
            {
                if (value < 1)
                    throw new ArgumentException("O número da página deve ser maior que 0.");
                _pageNumber = value;
            }
        }
    }
}
