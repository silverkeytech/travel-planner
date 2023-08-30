CREATE MIGRATION m1zujvwwmvd34zk36nckbjsyxfmodiivfgt5j4npufy2lnhmkecvma
    ONTO m12tp6wnyb4hxmgr6omfpcuwahfgvjreqlkc2zljn4rw4fcl5p5oja
{
  ALTER TYPE default::AdminActivity {
      CREATE LINK admin: default::Admin;
  };
};
