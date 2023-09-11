CREATE MIGRATION m1nubr4qfmm7fj4vhvuv3qpzbuxqqbqtm66dx56ju3imndlgcaq5mq
    ONTO m1xwhd24bgqfdmwgkucbbc7nvjxeunu4szjdd2rnondae4vdaxhoba
{
  ALTER TYPE default::Program {
      CREATE PROPERTY programs_Highlights: array<std::str>;
  };
};
