CREATE MIGRATION m1glqqe5nwecaiyicclewc6vu3l55t4b77jluo4377bgzeww2zg2oq
    ONTO m1z6fgaoyxxgbytktpprbggzijlbrcext33dgazxxisxzxtpe2ttfq
{
  ALTER TYPE default::AccommodationReview {
      CREATE PROPERTY nationality: std::str;
  };
};
