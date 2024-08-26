# DIRS21
Dynamic mapping system using .NET

To add a new partner:
  - Navigate to the Configs/Mapper folder. Create a new configuration file for the partner. The file should be in JSON format.
  - Set the "Copy to Output Directory" property to "Copy if newer" or "Copy always".
  - Ensure Config file contains at least the source and target details in the required format.
  - By default, the system will attempt to map models based on matching names if no custom mapping rules are provided. Ensure that the names in the config file match the names used in the system’s model definitions.
  - Define a custom mapping rule by implementing the IRule interface.
