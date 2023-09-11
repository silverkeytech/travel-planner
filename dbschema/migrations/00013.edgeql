CREATE MIGRATION m1xwhd24bgqfdmwgkucbbc7nvjxeunu4szjdd2rnondae4vdaxhoba
    ONTO m1xwlzc62uuwg7phubo7pgny3inevpfeh6r7lkdmbszu5ovxmquwga
{
  ALTER TYPE default::Program {
      DROP PROPERTY programs_Highlights;
  };
};
