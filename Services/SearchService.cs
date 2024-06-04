using DCADPropertyMap.Models;

namespace DCADPropertyMap.Services;

public class SearchService
{
    public List<SearchSetting> SearchSettings { get; set; }

    public SearchService()
    {
        InitializeSearchSettings();
    }

    private void InitializeSearchSettings()
    {
        SearchSettings = new List<SearchSetting>
            {
                new SearchSetting
                {
                    Key = "taxParcelLayer",
                    Label = "Account/Prop Addr/Owner Name",
                    Name = "Parcels",
                    IsParcelLayer = true,
                    InfoWindowHeader = "${SITEADDRESS}",
                    InfoWindowContent = "${PARCELID}",
                    LayerId = 4,
                    ParcelIdUnique = false,
                    LoginRequired = false,
                    QueryTaskUrl = "https://maps.dcad.org/prdwa/rest/services/Property/ParcelQuery/MapServer/4",
                    QueryFields = new List<QueryField>
                    {
                        new QueryField { Field = "PARCELID", AddressField = "SITEADDRESS" },
                        new QueryField { Field = "OWNERNME1", AddressField = "SITEADDRESS" }
                    },
                    ServiceURL = "https://maps.dcad.org/prdwa/rest/services/Property/ParcelQuery/MapServer/4",
                    SearchId = 0,
                    SubSearch = false,
                    Instructions = "Double-click in the search text box to enter new text. Search for parcel information using one of the formats in these examples:",
                    OutFields = "OBJECTID, PARCELID, SITEADDRESS, OWNERNME1",
                    ParcelQuery = "UPPER(PARCELID) LIKE '%${0}%' OR UPPER(SITEADDRESS) LIKE '%${0}%' OR UPPER(OWNERNME1) LIKE '%${0}%'",
                    ParcelAddressQueryUpdate = "UPPER(SITEADDRESS) LIKE '%${0}%'",
                    AddressQuery = true,
                    ReturnParcelList = false,
                    LocateParcelListItemQuery = "OBJECTID = ${OBJECTID}",
                    LocateParcelQuery = "PARCELID = '${0}'",
                    DisplayFields = new List<string> { "PARCELID", "SITEADDRESS" },
                    PrimaryDisplayField = 1,
                    DisplayNames = new List<string> { "Parcel ID", "Property Address" },
                    UseColor = true,
                    Color = "#00ff00",
                    Alpha = 0.1,
                    Fields = new List<Field>
                    {
                        new Field { DisplayText = "Parcel ID:", FieldName = "${LOWPARCELID}", DataType = "string" },
                        new Field { DisplayText = "Account Number:", FieldName = "${PARCELID}", DataType = "string", IsLink = true, Href = "https://www.dallascad.org/AcctDetail.aspx?ID=${PARCELID}", StaffHref = "https://www.dallascad.org/staff/AcctDetail.aspx?ID=${PARCELID}" },
                        new Field { DisplayText = "Neighborhood", FieldName = "${NGHBRHDCD}", DataType = "string" },
                        new Field { DisplayText = "Site Address:", FieldName = "${SITEADDRESS}", DataType = "string" },
                        new Field { DisplayText = "Map Grid:", FieldName = "${MAPGRID}", DataType = "string" },
                        new Field { DisplayText = "Account Type:", FieldName = "${USEDSCRP}", DataType = "string" },
                        new Field { DisplayText = "Legal Description 1:", FieldName = "${CNVYNAME}", DataType = "string" },
                        new Field { DisplayText = "Legal Description 2:", FieldName = "${PRPRTYDSCRP}", DataType = "string" },
                        new Field { DisplayText = "Doing Business As:", FieldName = "${DBA1}", DataType = "string" },
                        new Field { DisplayText = "Owner Name:", FieldName = "${OWNERNME1}", DataType = "string" },
                        new Field { DisplayText = "Owner Address:", FieldName = "${PSTLADDRESS}", DataType = "string" },
                        new Field { DisplayText = "Owner City:", FieldName = "${PSTLCITY}", DataType = "string" },
                        new Field { DisplayText = "Owner State:", FieldName = "${PSTLSTATE}", DataType = "string" },
                        new Field { DisplayText = "Owner Zip:", FieldName = "${PSTLZIP5}", DataType = "string" },
                        new Field { DisplayText = "Owner Zip +4:", FieldName = "${PSTLZIP4}", DataType = "string" },
                        new Field { DisplayText = "Value Header", FieldName = "----------------", DataType = "string" },
                        new Field { DisplayText = "Improvement Value:", FieldName = "${IMPVALUE}", DataType = "double" },
                        new Field { DisplayText = "Land Value:", FieldName = "${LNDVALUE}", DataType = "double" },
                        new Field { DisplayText = "", FieldName = "----------------", DataType = "string" },
                        new Field { DisplayText = "Market Value:", FieldName = "${CNTASSDVAL}", DataType = "double" },
                        new Field { DisplayText = "Prev. Mkt. Value:", FieldName = "${PRVASSDVAL}", DataType = "double" },
                        new Field { DisplayText = "Revaluation Year:", FieldName = "${REVALYR}", DataType = "integer" },
                        new Field { DisplayText = "Previous Revaluation Year:", FieldName = "${PRVRVALYR}", DataType = "integer" }
                    },
                    Examples = new List<Example>
                    {
                        new Example { FieldName = "Account Number", Syntax = "May be a 17 digit alphanumeric or numeric only entry", ExampleText = "00000776533000000" },
                        new Example { FieldName = "Property Address", Syntax = "May be any street name with or without street number and street suffix", ExampleText = "2949 N Stemmons Fwy" },
                        new Example { FieldName = "Owner Name", Syntax = "Last name First name (no comma)", ExampleText = "Doe John" },
                        new Example { FieldName = "Doing Business As", Syntax = "Enter only the first part of the business name.", ExampleText = "Dallas Central" }
                    },
                    SearchFields = new List<SearchField>
                    {
                        new SearchField { Field = "PARCELID" },
                        new SearchField { Field = "OWNERNME1" }
                    }
                }
            };
    }
}