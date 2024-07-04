import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Link from 'next/link';
import ArrowUpwardIcon from '@mui/icons-material/ArrowUpward';
import FacebookIcon from '@mui/icons-material/Facebook';
import InstagramIcon from '@mui/icons-material/Instagram';
import TwitterIcon from '@mui/icons-material/Twitter';
import YouTubeIcon from '@mui/icons-material/YouTube';
import { SvgIconComponent } from '@mui/icons-material';

interface MenuFooter {
    name: string;
    href: string;
}

interface MenuIcon {
    icon: SvgIconComponent;
    href: string;
}

interface MenuDecriptions {
    name: string;
    href: string;
}

const Footer = () => {
    const menuFooters: MenuFooter[] = [
        {
            name: 'XEM PHIM',
            href: '/',
        },
        {
            name: 'YÊU CẦU ANIME',
            href: '/',
        },
        {
            name: 'CHAT ANIME/DISCORD',
            href: '/',
        },
        {
            name: 'THUẬT NGỮ',
            href: '/',
        },
        {
            name: 'GROUP THẢO LUẬN',
            href: '/',
        },
    ];

    const menuIcons: MenuIcon[] = [
        {
            icon: FacebookIcon,
            href: '/',
        },
        {
            icon: InstagramIcon,
            href: '/',
        },
        {
            icon: TwitterIcon,
            href: '/',
        },
        {
            icon: YouTubeIcon,
            href: '/',
        },
    ];

    const menuDecriptions: MenuDecriptions[] = [
        {
            name: 'hanakakasi Fansub',
            href: '/',
        },
        {
            name: ', One Piece, Vua Hải Tặc Đảo Hải Tặc',
            href: '/',
        },
        {
            name: ', Thám Tử Lừng Danh Conan',
            href: '/',
        },
        {
            name: ', Hoạt Hình Trung Quốc',
            href: '/',
        },
    ];

    return (
        <Box>
            <Container sx={{ textAlign: 'center', padding: { xs: '0', md: '24px' } }}>
                <Box
                    sx={{
                        display: 'flex',
                        marginBottom: '20px',
                        alignItems: 'center',
                        backgroundColor: 'background.paper',
                        padding: '0 20px',
                        flexDirection: { xs: 'column', md: 'row' },
                        maxWidth: '1182px',
                        height: { xs: 'auto', md: '65px' },
                    }}
                >
                    <Box
                        sx={{
                            minWidth: '105px',
                            maxWidth: '108px',
                            lineHeight: '0',
                            marginRight: { xs: '0px', md: '2rem' },
                            paddingY: { xs: '15px', md: '0px' },
                        }}
                        component={Link}
                        href="/"
                    >
                        <img style={{ width: '100%' }} src="/logoz.webp" alt="My Image" />
                    </Box>
                    <Box
                        sx={{
                            display: 'flex',
                            flexGrow: 1,
                            alignItems: 'center',
                            flexDirection: { xs: 'column', md: 'row' },
                            paddingBottom: { xs: '16px', md: '0px' },
                            justifyContent: { xs: 'center', md: 'flex-start' },
                            width: { xs: '100%', md: 'auto' },
                        }}
                    >
                        {menuFooters.map((item, index) => (
                            <Box
                                key={index}
                                component={Link}
                                href={item.href}
                                sx={{
                                    textDecoration: 'none',
                                    height: { xs: '40px', md: 'auto' },
                                    backgroundColor: { xs: 'rgba(0,0,0,.2)', md: 'transparent' },
                                    width: { xs: '100%', md: 'auto' },
                                    marginBottom: { xs: '8px', md: '0' },
                                    borderRadius: { xs: '20px', md: '0' },
                                    display: { xs: 'flex', md: 'block' },
                                    alignItems: 'center',
                                }}
                            >
                                <Typography
                                    sx={{
                                        color: '#fff',
                                        fontSize: '13px',
                                        width: '100%',
                                        padding: ' 0 15px',
                                        textAlign: 'start',
                                    }}
                                >
                                    {item.name}
                                </Typography>
                            </Box>
                        ))}
                    </Box>
                    <Box sx={{ display: 'flex', paddingBottom: { xs: '24px', md: '0px' } }}>
                        {menuIcons.map((item, index) => {
                            const IconComponent = item.icon;
                            return (
                                <Box key={index} component={Link} href={item.href} sx={{ textDecoration: 'none' }}>
                                    <IconComponent
                                        sx={{
                                            height: '40px',
                                            width: '40px',
                                            padding: '6px',
                                            margin: '5px',
                                            backgroundColor: '#263238',
                                            opacity: '0.5',
                                            borderRadius: '3px',
                                            color: '#fff',
                                        }}
                                    />
                                </Box>
                            );
                        })}
                        <Box component={Link} href={`/`} sx={{ textDecoration: 'none' }}>
                            <ArrowUpwardIcon
                                sx={{
                                    height: '40px',
                                    width: '40px',
                                    padding: '6px',
                                    margin: '5px',
                                    backgroundColor: '#b5e745',
                                    borderRadius: '3px',
                                    color: '#fff',
                                }}
                            />
                        </Box>
                    </Box>
                </Box>
                <Box sx={{ fontSize: '12px', marginBottom: '19.2px' }}>
                    {menuDecriptions.map((item, index) => (
                        <Box
                            key={index}
                            component={Link}
                            href={item.href}
                            sx={{ textDecoration: 'none', color: '#8e8e8e' }}
                        >
                            {item.name}
                        </Box>
                    ))}
                </Box>
                <Typography sx={{ fontSize: '12px', color: '#78909c', marginBottom: '19.2px' }}>
                    Liên Hệ Quảng Cáo: ads@anime.tv
                </Typography>
                <Typography sx={{ fontSize: '12px', color: '#78909c', marginBottom: '16px' }}>
                    © Copyright 2024 Anime.TV. All rights reserved.
                </Typography>
            </Container>
        </Box>
    );
};

export default Footer;
