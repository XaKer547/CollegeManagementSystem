using Duende.IdentityServer.Models;

namespace SmartCollege.SSO;

public sealed record IdentityServerSettings
{
    public IReadOnlyCollection<ApiScope> ApiScopes { get; init; }
    public IReadOnlyCollection<ApiResource> ApiResources { get; init; }

    private IReadOnlyCollection<Client> _clients;

    public IReadOnlyCollection<Client> Clients
    {
        get
        {
            if(_clients is null)
                return Array.Empty<Client>();

            foreach (var client in _clients)
                client.ClientSecrets = client.ClientSecrets.Select(x => new Secret(x.Value.Sha256(), x.Expiration))
                    .ToArray();

            return _clients;
        }

        init => _clients = value;
    }

    public IReadOnlyCollection<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        ];
}
