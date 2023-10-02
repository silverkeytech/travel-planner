CREATE MIGRATION m1yoaknp3t33ovrhah3hga6rnyp5cxbjtzzsmta2wxdqlo3ppuzy2q
    ONTO m1yrq63zmas7qnk6qfycaty3eo3ndxht2ejwbvmib4ee77all5ge2q
{
  ALTER TYPE default::ActivityDetails {
      CREATE PROPERTY details: array<std::str>;
  };
};
