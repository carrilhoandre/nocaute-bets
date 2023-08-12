namespace Shared.Domain
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public override bool Equals(object entity)
        {
            if (!(entity is Entity entityToBeCompared))
                return false;

            if (ReferenceEquals(this, entityToBeCompared))
                return true;

            if (GetType() != entityToBeCompared.GetType())
                return false;

            return Id == entityToBeCompared.Id;
        }

        public static bool operator ==(Entity entityA, Entity entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entity entityA, Entity entityB)
        {
            return !(entityA == entityB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
