CREATE MIGRATION m1agjw3djlfc3qvdpn36hmf3uohfyoortvq5r5fwkfynab3ihv76rq
    ONTO m1zujvwwmvd34zk36nckbjsyxfmodiivfgt5j4npufy2lnhmkecvma
{
  ALTER TYPE default::Activity RENAME TO default::Program;
  ALTER TYPE default::ActivityProgramDetails RENAME TO default::ActivityDetails;
  ALTER TYPE default::Admin {
      DROP PROPERTY admin_role;
  };
  ALTER TYPE default::AdminActivity {
      ALTER LINK activity {
          RENAME TO program;
      };
  };
  ALTER TYPE default::Reservation {
      ALTER LINK activities {
          RENAME TO programs;
      };
  };
  ALTER TYPE default::Reservation {
      ALTER PROPERTY check_in {
          RENAME TO end_date;
      };
  };
  ALTER TYPE default::Reservation {
      ALTER PROPERTY check_out {
          RENAME TO start_date;
      };
  };
  ALTER TYPE default::Program {
      ALTER LINK programs {
          RENAME TO activities;
      };
  };
  ALTER TYPE default::ReservedRoom {
      CREATE PROPERTY check_in: std::datetime;
      CREATE PROPERTY check_out: std::datetime;
  };
  DROP SCALAR TYPE default::AdminRole;
};
