CREATE MIGRATION m1z6fgaoyxxgbytktpprbggzijlbrcext33dgazxxisxzxtpe2ttfq
    ONTO m1m5fwanio55cb2pzcs3jixwht2kpk2gf2ienymj7bpuawofxbnybq
{
  ALTER TYPE default::AccommodationReview {
      CREATE PROPERTY date: std::datetime;
  };
};
