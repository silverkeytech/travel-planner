CREATE MIGRATION m1xwlzc62uuwg7phubo7pgny3inevpfeh6r7lkdmbszu5ovxmquwga
    ONTO m1glqqe5nwecaiyicclewc6vu3l55t4b77jluo4377bgzeww2zg2oq
{
  ALTER TYPE default::Accommodation {
      ALTER LINK rooms {
          ON TARGET DELETE ALLOW;
      };
  };
};
