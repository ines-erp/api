namespace ERP_INES.Entities;

// todo: ensure that it will always match with some data in databases
public enum PermissionScope
{
    NONE = 0,
    ALL = 1,
    USERS = 2,
    SALES = 3,
    CRM = 4,
    INVENTORY = 5,
    FINANCE = 6,
    HR = 7,
}