CREATE MIGRATION m1jv6yoppohotfb4nttobmilfsgleexdx47ykouw7ybj2serxd2k5a
    ONTO m1kb4spzxcoybq5pzjdjqhdgzlksbn7637ilsnrimn4sujmylcvt3q
{
  ALTER TYPE default::Program {
      ALTER LINK activities {
          ON TARGET DELETE ALLOW;
      };
  };
};
