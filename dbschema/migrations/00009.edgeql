CREATE MIGRATION m1m5fwanio55cb2pzcs3jixwht2kpk2gf2ienymj7bpuawofxbnybq
    ONTO m1agjw3djlfc3qvdpn36hmf3uohfyoortvq5r5fwkfynab3ihv76rq
{
  ALTER SCALAR TYPE default::AccomodationFacilities RENAME TO default::AccommodationFacilities;
  ALTER SCALAR TYPE default::AccomodationMode RENAME TO default::AccommodationMode;
  ALTER TYPE default::Accomodation RENAME TO default::Accommodation;
  ALTER TYPE default::Accommodation {
      ALTER PROPERTY accomodation_facilities {
          RENAME TO accommodation_facilities;
      };
  };
  ALTER TYPE default::Accommodation {
      ALTER PROPERTY accomodation_modes {
          RENAME TO accommodation_modes;
      };
  };
  ALTER TYPE default::AccomodationReview RENAME TO default::AccommodationReview;
};
