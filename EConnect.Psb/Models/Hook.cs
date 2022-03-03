﻿using System;

namespace EConnect.Psb.Models;

public record Hook(
    string Id,
    string Action,
    string Name,
    string[] Topics,
    bool IsActive,
    DateTimeOffset? CreatedOn = null,
    DateTimeOffset? ChangedOn = null)
{
    public string Id { get; } = Id;
    public string Action { get; } = Action;
    public string Name { get; } = Name;
    public string[] Topics { get; } = Topics;
    public bool IsActive { get; } = IsActive;
    public DateTimeOffset? CreatedOn { get; } = CreatedOn;
    public DateTimeOffset? ChangedOn { get; } = ChangedOn;
}