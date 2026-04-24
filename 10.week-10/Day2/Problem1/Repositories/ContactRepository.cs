using week_10_day2.Models;

namespace week_10_day2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();
        public List<Contact> GetAll() => _contacts;
        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Contact contact)
        {
            contact.Id = _contacts.Count == 0 ? 1 : _contacts.Max(c => c.Id) + 1;
            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existing = GetById(contact.Id);
            if (existing == null) return;

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
        }
        public void Delete(int id)
        {
            var contact = GetById(id);
            if (contact != null)
                _contacts.Remove(contact);
        }
    }
}
