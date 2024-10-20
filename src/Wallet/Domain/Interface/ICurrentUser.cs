namespace Template.Domain.Interface
{
    public interface ICurrentUser
    {
        string GetTenantUser();
        void SetTenantUser(string tenantId);

        string GetGuidUser();
        string GetNameUser();

    }
}
