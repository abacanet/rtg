﻿using System;
using System.Collections.Generic;

namespace Serenity.Data
{
    /// <summary>
    ///   Extensions for objects implementing IDbWhere interface.</summary>
    public static class EntityQueryExtensions
    {
        /// <summary>
        ///   Adds all field values in a row to where clause with equality operator and auto named parameters 
        ///   (field name prefixed with '@').</summary>
        /// <param field="row">
        ///   The row with modified field values to be added to the where clause (key row).  Must be in TrackAssignments mode, 
        ///   or an exception is raised.</param>
        /// <returns>
        ///   Object itself.</returns>
        public static T WhereEqual<T>(this T self, Row row) where T : IFilterableQuery
        {
            if (row == null)
                throw new ArgumentNullException("row");
            if (!row.TrackAssignments)
                throw new ArgumentException("row must be in TrackAssignments mode to determine modified fields.");
            foreach (var field in row.GetFields())
                if (row.IsAssigned(field))
                    self.Where(new Criteria(field) == self.AddParam(field.AsObject(row)));
            return self;
        }

        /// <summary>
        ///   Sets all field values in a row with auto named parameters (field name prefixed with '@').</summary>
        /// <param field="row">
        ///   The row with modified field values. Must be in TrackAssignments mode, or an exception is raised.</param>
        /// <returns>
        ///   Object itself.</returns>
        public static T Set<T>(this T self, Row row, IField exclude = null) where T : ISetFieldByStatement
        {
            if (row == null)
                throw new ArgumentNullException("row");

            if (!row.TrackAssignments)
                throw new ArgumentException("row must be in TrackAssignments mode to determine modified fields.");

            foreach (var field in row.GetFields())
                if (!ReferenceEquals(field, exclude) && row.IsAssigned(field))
                    self.Set((IField)field, field.AsObject(row));

            return self;
        }

        /// <summary>
        ///   Adds actual table fields in a row to select list of a query.</summary>
        /// <param name="query">
        ///   Query to select fields into (required).</param>
        /// <param name="row">
        ///   Row with fields to be selected (required).</param>
        /// <param name="exclude">
        ///   Fields to be excluded (optional).</param>
        public static SqlQuery SelectTableFields(this SqlQuery query, Row row, params Field[] exclude)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            if (row == null)
                throw new ArgumentNullException("row");

            HashSet<Field> excludeFields =
                (exclude != null && exclude.Length > 0) ? new HashSet<Field>(exclude) : null;

            var fields = row.GetFields();

            for (int i = 0; i < row.FieldCount; i++)
            {
                Field field = fields[i];
                if (EntityFieldExtensions.IsTableField(field))
                {
                    if (excludeFields == null ||
                        !excludeFields.Contains(field))
                        query.Select(field);
                }
            }

            return query;
        }

        /// <summary>
        ///   Adds foreign / calculated table fields in a row to select list of a query.</summary>
        /// <param name="query">
        ///   Query to select fields into (required).</param>
        /// <param name="row">
        ///   Row with fields to be selected (required).</param>
        /// <param name="exclude">
        ///   Fields to be excluded (optional).</param>
        public static SqlQuery SelectForeignFields(this SqlQuery query, Row row, params Field[] exclude)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            if (row == null)
                throw new ArgumentNullException("row");

            HashSet<Field> excludeFields =
                (exclude != null && exclude.Length > 0) ? new HashSet<Field>(exclude) : null;

            var fields = row.GetFields();

            for (int i = 0; i < row.FieldCount; i++)
            {
                Field field = fields[i];
                if (!EntityFieldExtensions.IsTableField(field) &&
                    (field.Flags & FieldFlags.NotMapped) != FieldFlags.NotMapped)
                {
                    if (excludeFields == null ||
                        !excludeFields.Contains(field))
                        query.Select(field);
                }
            }

            return query;
        }

        /// <summary>
        ///   Adds foreign / calculated table fields in a row to select list of a query.</summary>
        /// <param name="query">
        ///   Query to select fields into (required).</param>
        /// <param name="row">
        ///   Row with fields to be selected (required).</param>
        /// <param name="exclude">
        ///   Fields to be excluded (optional).</param>
        public static SqlQuery SelectNonTableFields(this SqlQuery query)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            var ext = (ISqlQueryExtensible)query;

            foreach (var field in ((Row)ext.FirstIntoRow).GetFields())
            {
                if (!EntityFieldExtensions.IsTableField(field) &&
                    (field.Flags & FieldFlags.NotMapped) != FieldFlags.NotMapped)
                {
                    query.Select(field);
                }
            }

            return query;
        }

        /// <summary>
        ///   Adds actual table fields in a row to select list of a query.</summary>
        /// <param name="query">
        ///   Query to select fields into (required).</param>
        /// <param name="exclude">
        ///   Fields to be excluded (optional).</param>
        public static SqlQuery SelectTableFields(this SqlQuery query, params Field[] exclude)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            var ext = (ISqlQueryExtensible)query;

            return SelectTableFields(query, (Row)ext.FirstIntoRow, exclude);
        }

        /// <summary>
        ///   Sets a field value with a parameter.</summary>
        /// <param field="field">
        ///   Field name.</param>
        /// <param field="param">
        ///   Parameter name</param>
        /// <param field="value">
        ///   Parameter value</param>
        /// <returns>
        ///   Object itself.</returns>
        public static T Set<T>(this T self, IField field, object value) where T : ISetFieldByStatement
        {
            var param = self.AddParam(value);
            self.SetTo(field.Name, param.Name);
            return self;
        }
    }
}