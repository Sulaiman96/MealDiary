import React from "react";
import {
    Navbar,
    MobileNav,
    Typography,
    Button,
    Menu,
    MenuHandler,
    MenuList,
    MenuItem,
    Avatar,
    IconButton,
} from "@material-tailwind/react";
import {
    CubeTransparentIcon,
    UserCircleIcon,
    ChevronDownIcon,
    Cog6ToothIcon,
    InboxArrowDownIcon,
    LifebuoyIcon,
    PowerIcon,
    Bars2Icon,
    InformationCircleIcon,
    CurrencyPoundIcon
} from "@heroicons/react/24/solid";
import { Link } from "react-router-dom";
import { useAuth } from "../Context/useAuth";
import companyLogo from "./icons/companyLogo.svg"

interface Props { }

interface ProfileMenuItem {
    label: string;
    icon: React.ForwardRefExoticComponent<Omit<React.SVGProps<SVGSVGElement>, "ref"> & {
        title?: string | undefined;
        titleId?: string | undefined;
    } & React.RefAttributes<SVGSVGElement>>;
}

const profileMenuItems: ProfileMenuItem[] = [
    {
        label: "My Profile",
        icon: UserCircleIcon,
    },
    {
        label: "Edit Profile",
        icon: Cog6ToothIcon,
    },
    {
        label: "Help",
        icon: LifebuoyIcon,
    },
    {
        label: "Sign Out",
        icon: PowerIcon,
    }
];

interface NavListItem {
    label: string;
    icon: React.ForwardRefExoticComponent<Omit<React.SVGProps<SVGSVGElement>, "ref"> & {
        title?: string | undefined;
        titleId?: string | undefined;
    } & React.RefAttributes<SVGSVGElement>>;
}

const navListItems: NavListItem[] = [
    {
        label: "About",
        icon: InformationCircleIcon,
    },
    {
        label: "Features",
        icon: CubeTransparentIcon,
    },
    {
        label: "Pricing",
        icon: CurrencyPoundIcon,
    },
];

function ProfileMenu() {
    const [isMenuOpen, setIsMenuOpen] = React.useState(false);
    const { isLoggedIn, user, logout } = useAuth();
    const closeMenu = () => setIsMenuOpen(false);

    return (
        <Menu open={isMenuOpen} handler={setIsMenuOpen} placement="bottom-end">
            <MenuHandler>
                <Button
                    variant="text"
                    size="lg"
                    color="blue-gray"
                    className="flex items-center gap-1 rounded-full py-0.5 pr-2 pl-4 lg:ml-auto text-blue-gray-800 hover:text-darkBlue"
                >
                    <div>Welcome, {user?.firstName} </div>
                    <Avatar
                        variant="circular"
                        size="lg"
                        alt="profile pic"
                        className="border border-gray-900 p-0.5"
                        src="https://media.licdn.com/dms/image/D4E03AQF4ZB6Y2RQ3sg/profile-displayphoto-shrink_800_800/0/1699983286956?e=1714608000&v=beta&t=O2PKJ7nxPPu89dydF9j6u1usigfVkai3zHDc46RsFlI"
                    />
                    <ChevronDownIcon
                        strokeWidth={2.5}
                        className={`h-4 w-4 transition-transform ${isMenuOpen ? "rotate-180" : ""
                            }`}
                    />
                </Button>
            </MenuHandler>

            <MenuList className="p-1">
                {profileMenuItems.map(({ label, icon }, key) => {
                    const isLastItem = key === profileMenuItems.length - 1;
                    return (
                        <MenuItem
                            key={label}
                            onClick={closeMenu}
                            className={`flex items-center gap-2 rounded ${isLastItem
                                ? "hover:bg-red-500/10 focus:bg-red-500/10 active:bg-red-500/10"
                                : ""
                                }`
                            }
                        >
                            {
                                React.createElement(icon, {
                                    className: `h-4 w-4 ${isLastItem ? "text-red-500" : ""}`,
                                    strokeWidth: 2,
                                })
                            }
                            {
                                isLastItem ? (
                                    <a
                                        onClick={logout} >
                                        <Typography
                                            as="span"
                                            variant="small"
                                            className="font-normal"
                                            color="red"
                                        >
                                            {label}
                                        </Typography>
                                    </a>
                                ) : (
                                    <Typography
                                        as="span"
                                        variant="small"
                                        className="font-normal"
                                        color="inherit"
                                    >
                                        {label}
                                    </Typography>
                                )}
                        </MenuItem>
                    );
                })}
            </MenuList >
        </Menu >
    );
};


function NavList() {
    return (
        <ul className="mt-2 mb-2 flex flex-col lg:mb-1 lg:mt-0 lg:flex-row lg:items-end">
            {navListItems.map(({ label, icon }, key) => (
                <Typography
                    key={label}
                    as="li"
                    variant="h5"
                    className="font-medium text-blue-gray-900"
                >
                    <MenuItem className="flex items-center gap-1 lg:rounded-full">
                        {React.createElement(icon, { className: "h-[30px] w-[30px]" })}{" "}
                        <span className="text-gray-900"> {label}</span>
                    </MenuItem>
                </Typography>
            ))}
        </ul>
    );
};

const Navigationbar = (props: Props) => {
    const [isNavOpen, setIsNavOpen] = React.useState(false);
    const { isLoggedIn, user, logout } = useAuth();

    const toggleIsNavOpen = () => setIsNavOpen((cur) => !cur);

    React.useEffect(() => {
        window.addEventListener(
            "resize",
            () => window.innerWidth >= 960 && setIsNavOpen(false),
        );
    }, []);

    return (
        <Navbar className="mx-auto max-w-screen-xl p-2 lg:rounded-full lg:pl-6">
            <div className="relative mx-auto flex items-center justify-center text-black">
                <Link to={'/'}>
                    <img
                        className="p-2 ml-2 h-20 w-20"
                        src={companyLogo}
                    >
                    </img>
                </Link>
                <Link to={'/'} style={{ textDecoration: 'none', }} className="text-black">
                    <Typography
                        as="head"
                        variant="h3"
                        className="mr-4 cursor-pointer py-2 font-medium"
                    >
                        Meal Diary
                    </Typography>
                </Link>
                <div className="hidden lg:block">
                    <NavList />
                </div>
                <IconButton
                    size="sm"
                    variant="text"
                    onClick={toggleIsNavOpen}
                    className="ml-auto mr-2 lg:hidden"
                >
                    <Bars2Icon className="h-6 w-6" />
                </IconButton>
                {isLoggedIn() ? (
                    <>
                        <ProfileMenu />
                    </>
                ) : (
                    <>
                        <Link to={"/login"} className="mr-6 flex items-center gap-1 lg:ml-auto hover:text-darkBlue text-blue-gray-800"
                            style={{ textDecoration: 'none', }}>
                            <Button
                                className="rounded-full "
                                variant="filled"
                                color="black"
                                size="lg">
                                Login
                            </Button>
                        </Link>
                    </>
                )}

            </div>
            <MobileNav open={isNavOpen} className="overflow-scroll">
                <NavList />
            </MobileNav>
        </Navbar>
    );
};

export default Navigationbar;