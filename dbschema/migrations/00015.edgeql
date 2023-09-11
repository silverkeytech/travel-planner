CREATE MIGRATION m1kb4spzxcoybq5pzjdjqhdgzlksbn7637ilsnrimn4sujmylcvt3q
    ONTO m1nubr4qfmm7fj4vhvuv3qpzbuxqqbqtm66dx56ju3imndlgcaq5mq
{
  ALTER TYPE default::Program {
      ALTER PROPERTY programs_Highlights {
          RENAME TO program_Highlights;
      };
  };
};
